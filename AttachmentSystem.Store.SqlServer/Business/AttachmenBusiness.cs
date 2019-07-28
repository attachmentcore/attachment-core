using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Extensions;
using AttachmentSystem.Common.Models.AttachmentItemModels;
using AttachmentSystem.Common.Models.AttacmentModels;
using AttachmentSystem.Store.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AttachmentSystem.Store.SqlServer.Businesses
{
    public class SqlServerAttachmenBusiness : IAttachmentBusiness
    {
        AttachmentDbContext _DbContext;
        /// <summary>
        /// Create SqlServerAttachmenBusiness based on given connection string 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static SqlServerAttachmenBusiness SqlServerAttachmenBusinessFactory(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AttachmentDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var dbContext = new AttachmentDbContext(optionsBuilder.Options);
            return new SqlServerAttachmenBusiness(dbContext);
        }
        public SqlServerAttachmenBusiness(AttachmentDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        #region Methods
        public AttachmentModel CreateAttachmentTemporarily(TemporaryAttachmentKeyModel model)
        {
            if (!model.EntityName.HasValue() || !model.FieldName.HasValue() || !model.Token.HasValue())
                throw new ArgumentNullException();
            var attachment = new Context.Attachment()
            {
                EntityName = model.EntityName,
                FieldName = model.FieldName,
                Token = model.Token
            };

            _DbContext.Attachments.Add(attachment).State = EntityState.Added;
            _DbContext.SaveChanges();
            return new AttachmentModel
            {
                AttachmentId = attachment.Id,
                TotalCount = 0
            };
        }
        public int PreserveAttachment(PreserveAttachmentModel model)
        {
            var attachment = _DbContext.Attachments
                .SingleOrDefault(x => x.EntityName == model.EntityName &&
                                      x.FieldName == model.FieldName &&
                                      x.EntityId == model.EntityId);
            if (attachment == null)
                throw new NullReferenceException();
            attachment.EntityId = model.EntityId;
            _DbContext.SaveChanges();
            return attachment.Id;
        }
        public AttachmentModel CreateAttachment(AttachmentKeyModel model)
        {
            if (!model.EntityName.HasValue() || !model.FieldName.HasValue() || !model.EntityId.HasValue())
                throw new ArgumentNullException();
            var attachment = new Context.Attachment()
            {
                EntityName = model.EntityName,
                FieldName = model.FieldName,
                EntityId = model.EntityId
            };

            _DbContext.Attachments.Add(attachment).State = EntityState.Added;
            _DbContext.SaveChanges();
            return new AttachmentModel
            {
                AttachmentId = attachment.Id,
                TotalCount = 0
            };
        }
        public AttachmentModel GetAttachmentId(AttachmentKeyModel model)
        {
            var attachment = _DbContext.Attachments.Where(x =>
                x.EntityName == model.EntityName &&
                x.FieldName == model.FieldName &&
                x.EntityId == model.EntityId
            )
            .Select(x => new AttachmentModel
            {
                AttachmentId = x.Id,
                TotalCount = x.AttachmentItems.Count()
            }).FirstOrDefault();
            return attachment;
        }
        public void DeleteAttachmentItem(DeleteAttachmentItemModel model)
        {
            _DbContext.AttachmentItems.RemoveRange(_DbContext.AttachmentItems
                .Where(x => model.AttachmentItemId.Contains(x.Id) &&
                            x.Attachment.EntityName == model.EntityName &&
                            x.Attachment.FieldName == model.FieldName &&
                            x.Attachment.EntityId == model.EntityId &&
                            x.Attachment.Id == model.AttachmentId));
            _DbContext.SaveChanges();
        }
        public AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel)
        {
            var totalCount = _DbContext.AttachmentItems
                            .Where(x => x.AttachmentId == searchModel.AttachmentId &&
                            x.Attachment.EntityName == searchModel.EntityName &&
                            x.Attachment.FieldName == searchModel.FieldName &&
                            x.Attachment.EntityId == searchModel.EntityId)
                            .Count();
            var pageCount = (int)Math.Ceiling((double)totalCount / searchModel.PageSize);
            var ResultPage = new List<Common.Models.AttachmentItemModels.AttachmentItem>();
            if (pageCount > 0)
            {
                searchModel.PageIndex = searchModel.PageIndex > pageCount ? pageCount : searchModel.PageIndex;
                ResultPage = _DbContext.AttachmentItems
                                .Where(x => x.AttachmentId == searchModel.AttachmentId &
                                            x.Attachment.EntityName == searchModel.EntityName &&
                                            x.Attachment.FieldName == searchModel.FieldName &&
                                            x.Attachment.EntityId == searchModel.EntityId)
                                .Skip(searchModel.PageSize * (searchModel.PageIndex - 1))
                                .Take(searchModel.PageSize)
                                .Select(x => new Common.Models.AttachmentItemModels.AttachmentItem
                                {
                                    Id = x.Id,
                                    AttachmentId = x.AttachmentId,
                                    Description = x.Description,
                                    FileExtension = x.FileExtension,
                                    FileName = x.FileName,
                                    FileSize = x.FileSize,
                                    UploadDate = x.UploadDate,
                                    Owner = x.Owner
                                })
                                .ToList();
            }
            var result = new AttachmentItemPagedList
            {
                Items = ResultPage,
                PageIndex = searchModel.PageIndex,
                PageSize = searchModel.PageSize,
                TotalItemsCount = totalCount
            };
            return result;
        }
        public Common.Models.AttachmentItemModels.AttachmentItem GetAttachmentItem(AttachmentItemKeyModel model)
        {
            var query = _DbContext.AttachmentItems
                            .Where(x => x.Id == model.AttachmentItemId &&
                                        x.Attachment.EntityName == model.EntityName &&
                                        x.Attachment.FieldName == model.FieldName &&
                                        x.Attachment.EntityId == model.EntityId)
                                         .Include(x => x.Attachment);
            return query.Select(x => new Common.Models.AttachmentItemModels.AttachmentItem
            {
                Id = x.Id,
                AttachmentId = x.AttachmentId,
                Description = x.Description,
                FileExtension = x.FileExtension,
                FileName = x.FileName,
                FileSize = x.FileSize,
                UploadDate = x.UploadDate,
                Owner = x.Owner,
                Attachment =  new Common.Models.AttacmentModels.Attachment
                {
                    Id = x.Attachment.Id,
                    EntityId = x.Attachment.EntityId,
                    EntityName = x.Attachment.EntityName,
                    FieldName = x.Attachment.FieldName,
                } 
            })
            .FirstOrDefault();
        }
        public void UploadAttachmentItem(UploadAttachmentItemModel model)
        {
            var attachment = _DbContext.Attachments.SingleOrDefault(x => x.Id == model.AttachmentId &&
                                                                         x.EntityName == model.EntityName &&
                                                                         x.FieldName == model.FieldName &&
                                                                         x.EntityId == model.EntityId);
            foreach (var item in model.FileContent)
            {
                var attachmentItem = new AttachmentSystem.Store.SqlServer.Context.AttachmentItem
                {
                    AttachmentId = attachment.Id,
                    Description = model.Description,
                    UploadDate = DateTime.Now,
                };
                using (var attachmentBytes = item.OpenReadStream())
                using (var memoryStream = new MemoryStream())
                {
                    attachmentBytes.CopyTo(memoryStream);
                    attachmentItem.FileContent = memoryStream.ToArray();

                    attachmentItem.FileExtension = item.ContentType;
                    attachmentItem.FileName = item.FileName;
                    attachmentItem.FileSize = (int)(memoryStream.Length);

                }
                _DbContext.AttachmentItems.Add(attachmentItem).State = EntityState.Added;
            }

            _DbContext.SaveChanges();
        }
        public AttachmentItemDownloadModel DownloadAttachmentItem(AttachmentItemKeyModel model)
        {
            var query = _DbContext.AttachmentItems
                            .Where(x => x.Id == model.AttachmentItemId &&
                                        x.Attachment.EntityName == model.EntityName &&
                                        x.Attachment.FieldName == model.FieldName &&
                                        x.Attachment.EntityId == model.EntityId);
            return query.Select(x => new AttachmentItemDownloadModel
            {
                FileContent = new MemoryStream(x.FileContent) ,
                FileExtension = x.FileExtension,
                FileName = x.FileName,
            })
            .FirstOrDefault();
        }
        #endregion
    }
}
