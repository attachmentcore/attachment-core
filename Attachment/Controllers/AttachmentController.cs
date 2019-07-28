using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Decorators;
using AttachmentSystem.Common.Extensions;
using AttachmentSystem.Common.Models.AttachmentItemModels;
using AttachmentSystem.Common.Models.AttacmentModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace AttachmentSystem.Controllers
{
    public class AttachmentController : Controller
    {
        private IAttachmentBusiness attachmentBusiness;
        private IAttachmentSessionProvider tokenProvider;
        #region Constructor
        public AttachmentController(AuthorizationAttachmnetBusinessDecorator attachmentBusiness, IAttachmentSessionProvider tokenProvider)
        {
            this.tokenProvider = tokenProvider;
        }
        #endregion

        #region Attachment API
        [HttpGet]
        public ActionResult GetAttachmentId(AttachmentKeyModel model)
        {
            try
            {
                if (!model.FieldName.HasValue() || !model.EntityName.HasValue())
                    throw new ArgumentNullException();
                if (model.EntityId.HasValue())
                {
                    var attachmentKeyModel = new AttachmentKeyModel {EntityName = model.EntityName,FieldName = model.FieldName,EntityId = model.EntityId };
                    var attachmentId = attachmentBusiness.GetAttachmentId(attachmentKeyModel);//check read permission
                    if (attachmentId == null)
                        return Ok(attachmentBusiness.CreateAttachment(attachmentKeyModel));//check create permission
                    return Ok(attachmentId);
                }
                else
                {
                    var token = tokenProvider.GetAttachmentToken();
                    if (!token.HasValue())
                        token = tokenProvider.SetAttachmentToken();
                    var tempAttachmentKeyModel = new TemporaryAttachmentKeyModel { EntityName = model.EntityName,FieldName = model.FieldName,Token = token };
                    return Ok(attachmentBusiness.CreateAttachmentTemporarily(tempAttachmentKeyModel));//check create permission
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult GetAllAttachmentItems(AttachmentItemSearchModel searchModel)
        {
            try
            {
                var result = attachmentBusiness.GetAllAttachmentItems(searchModel);//check read permission
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult Upload([FromForm]UploadAttachmentItemModel attachmentItemViewModel)
        {
            try
            {
                attachmentBusiness.UploadAttachmentItem(attachmentItemViewModel);//check upload permission
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult Download(AttachmentItemKeyModel model)
        {
            try
            {
                var item = attachmentBusiness.DownloadAttachmentItem(model);//check download permission
                if (item == null)
                    throw new FileNotFoundException();
                
                return File(item.FileContent, item.FileExtension, item.FileName);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public ActionResult Delete(DeleteAttachmentItemModel model)
        {
            try
            {
                attachmentBusiness.DeleteAttachmentItem(model);//check delete permission
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult GetInfo(AttachmentItemKeyModel model)
        {
            try
            {
                var attachmentItem = attachmentBusiness.GetAttachmentItem(model);//check details permission
                if (attachmentItem == null)
                    return NotFound();
                return Ok(attachmentItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }

}