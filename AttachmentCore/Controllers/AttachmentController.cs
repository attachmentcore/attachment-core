using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Decorators;
using AttachmentCore.Common.Extensions;
using AttachmentCore.Common.Models.AttachmentItemModels;
using AttachmentCore.Common.Models.AttachmentModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace AttachmentCore.Controllers
{
    public class AttachmentController : Controller
    {
        private IAttachmentBusiness attachmentBusiness;
        private IAttachmentSessionProvider tokenProvider;
        #region Constructor
        public AttachmentController(
            IAttachmentBusiness attachmentBusiness,
            IAttachmentSessionProvider tokenProvider)
        {
            this.attachmentBusiness = attachmentBusiness;
            this.tokenProvider = tokenProvider;
        }
        #endregion

        #region Attachment API
        [HttpGet]
        public ActionResult GetAttachmentId(AttachmentKeyModel model)
        {
            try
            {
                model.CheckArgumentIsNull(nameof(model));
                model.FieldName.CheckArgumentIsNullOrEmpty(nameof(model.FieldName));
                model.EntityName.CheckArgumentIsNullOrEmpty(nameof(model.EntityName));

                if (model.EntityId.HasValue())
                {
                    var attachmentId = attachmentBusiness.GetAttachmentId(model);//check read permission
                    if (attachmentId == null)
                        return Ok(attachmentBusiness.CreateAttachment(model));//check create permission
                    return Ok(attachmentId);
                }
                else
                {
                    var token = tokenProvider.GetAttachmentToken();
                    if (!token.HasValue())
                        token = tokenProvider.SetAttachmentToken();
                    var tempAttachmentKeyModel = new TemporaryAttachmentKeyModel { EntityName = model.EntityName, FieldName = model.FieldName, Token = token };
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
            catch (Exception)
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
                    return NotFound();

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