using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.AttachmentItemModels;
using AttachmentCore.Common.Models.AttachmentModels;
using AttachmentCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class AttachmentControllerTest
    {
        Mock<IAttachmentBusiness> attachmentBusiness;
        Mock<IAttachmentSessionProvider> attachmentTokenProvider;
        Mock<AttachmentController> attachmentController;
        [SetUp]
        public void Setup()
        {
            attachmentBusiness = new Mock<IAttachmentBusiness>();
            attachmentTokenProvider = new Mock<IAttachmentSessionProvider>();
            attachmentController = new Mock<AttachmentController>(attachmentBusiness.Object,attachmentTokenProvider.Object);
        }

        #region GetAttachmentId
        [Test(Description = "GetAttachmentId")]
        [TestCase(null, null, "1")]
        public void GetAttachmentId_PassNullArgument_GetBadRequest(string entity, string field, string id)
        {
            attachmentController.Setup((x) => x.BadRequest());

            var result = attachmentController.Object.GetAttachmentId(new AttachmentKeyModel { EntityId = id, FieldName = field, EntityName = entity });

            attachmentController.Verify(x => x.BadRequest(), Times.Once());
        }
        [Test(Description = "GetAttachmentId")]
        public void GetAttachmentId_PassNull_GetBadRequest()
        {
            attachmentController.Setup((x) => x.BadRequest());

            var result = attachmentController.Object.GetAttachmentId(null);

            attachmentController.Verify(x => x.BadRequest(), Times.Once());
        }
        [Test(Description = "GetAttachmentId")]
        public void GetAttachmentId_PassValidArgument_LackofAttachment_GetBadRequest()
        {
            var model = new AttachmentKeyModel { EntityId = "1", FieldName = "Image", EntityName = "Person" };
            var resultModel = new AttachmentModel { AttachmentId = 2, TotalCount = 0 };
            attachmentBusiness.Setup((x) => x.GetAttachmentId(It.IsAny<AttachmentKeyModel>())).Returns((AttachmentModel)null);
            attachmentBusiness.Setup((x) => x.CreateAttachment(It.IsAny<AttachmentKeyModel>())).Returns(resultModel);
            attachmentController.Setup((x) => x.Ok(resultModel));

            var result = attachmentController.Object.GetAttachmentId(model);

            attachmentController.Verify(x => x.Ok(resultModel), Times.Once());
        }
        [Test(Description = "GetAttachmentId")]
        public void GetAttachmentId_PassValidArgument_ExistingAttachment_GetBadRequest()
        {
            //arrange
            var model = new AttachmentKeyModel { EntityId = null, FieldName = "Image", EntityName = "Person" };
            var resultModel = new AttachmentModel { AttachmentId = 2, TotalCount = 0 };
            attachmentTokenProvider.Setup((x) => x.GetAttachmentToken()).Returns("1");
            attachmentBusiness.Setup((x) => x.CreateAttachmentTemporarily(It.IsAny<TemporaryAttachmentKeyModel>())).Returns(resultModel);
            attachmentController.Setup((x) => x.Ok(resultModel));
            //act
            var result = attachmentController.Object.GetAttachmentId(model);
            //assert
            attachmentController.Verify(x => x.Ok(resultModel), Times.Once());
        }
        [Test(Description = "GetAttachmentId")]
        public void GetAttachmentId_validArgumentWithoutToken_GetBadRequest()
        {
            //arrange
            var model = new AttachmentKeyModel { EntityId = null, FieldName = "Image", EntityName = "Person" };
            var resultModel = new AttachmentModel { AttachmentId = 2, TotalCount = 0 };
            attachmentTokenProvider.Setup((x) => x.GetAttachmentToken()).Returns((string)null);
            attachmentTokenProvider.Setup((x) => x.SetAttachmentToken()).Returns("1");
            attachmentBusiness.Setup((x) => x.CreateAttachmentTemporarily(It.IsAny<TemporaryAttachmentKeyModel>())).Returns(resultModel);
            attachmentController.Setup((x) => x.Ok(resultModel));
            //act
            var result = attachmentController.Object.GetAttachmentId(model);
            //assert
            attachmentController.Verify(x => x.Ok(resultModel), Times.Once());
        }
        #endregion

        #region GetAllAttachmentItems
        [Test(Description = "GetAllAttachmentItems")]
        public void GetAllAttachmentItems_throwException_GetBadRequest()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.GetAllAttachmentItems(It.IsAny<AttachmentItemSearchModel>())).Throws(new Exception());
            attachmentController.Setup((x) => x.BadRequest());
            //act
            var result = attachmentController.Object.GetAllAttachmentItems(new AttachmentItemSearchModel());
            //assert
            attachmentController.Verify(x => x.BadRequest(), Times.Once());
        }
        [Test(Description = "GetAllAttachmentItems")]
        public void GetAllAttachmentItems_returnNull_GetNotFound()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.GetAllAttachmentItems(It.IsAny<AttachmentItemSearchModel>())).Returns((AttachmentItemPagedList)null);
            attachmentController.Setup((x) => x.NotFound());
            //act
            var result = attachmentController.Object.GetAllAttachmentItems(new AttachmentItemSearchModel());
            //assert
            attachmentController.Verify(x => x.NotFound(), Times.Once());
        }
        #endregion

        #region Upload
        [Test(Description = "Upload")]
        public void Upload_NullArgument_ReturnBadRequest()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.UploadAttachmentItem(It.IsAny<UploadAttachmentItemModel>())).Throws(new Exception());
            attachmentController.Setup((x) => x.BadRequest());
            //act
            var result = attachmentController.Object.Upload(new UploadAttachmentItemModel());
            //assert
            attachmentController.Verify(x => x.BadRequest(), Times.Once());
        }
        [Test(Description = "Upload")]
        public void Upload_NormalBehaviour_ReturnBadRequest()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.UploadAttachmentItem(It.IsAny<UploadAttachmentItemModel>()));
            attachmentController.Setup((x) => x.Ok());
            //act
            var result = attachmentController.Object.Upload(new UploadAttachmentItemModel());
            //assert
            attachmentController.Verify(x => x.Ok(), Times.Once());
        }
        #endregion

        #region Download
        [Test(Description = "Download")]
        public void Download_ReturnNull_ReturnNotFound()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.DownloadAttachmentItem(It.IsAny<AttachmentItemKeyModel>())).Returns((AttachmentItemDownloadModel)null);
            attachmentController.Setup((x) => x.NotFound());
            //act
            var result = attachmentController.Object.Download(null);
            //assert
            attachmentController.Verify(x => x.NotFound(), Times.Once());
        }
        [Test(Description = "Download")]
        public void Download_ThrowException_ReturnNotFound()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.DownloadAttachmentItem(It.IsAny<AttachmentItemKeyModel>())).Throws(new Exception());
            attachmentController.Setup((x) => x.BadRequest());
            //act
            var result = attachmentController.Object.Download(null);
            //assert
            attachmentController.Verify(x => x.BadRequest(), Times.Once());
        }
        [Test(Description = "Download")]
        public void Download_ReturnValidValue_ReturnOk()
        {
            //arrange
            var resultModel = new AttachmentItemDownloadModel();
            attachmentBusiness.Setup((x) => x.DownloadAttachmentItem(It.IsAny<AttachmentItemKeyModel>())).Returns(resultModel);
            attachmentController.Setup((x) => x.File(It.IsAny<Stream>(),It.IsAny<string>(),It.IsAny<string>()));
            //act
            var result = attachmentController.Object.Download(null);
            //assert
            attachmentController.Verify(x => x.File(It.IsAny<Stream>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }
        #endregion

        #region Delete
        [Test(Description = "Delete")]
        public void Delete_NullArgument_ReturnBadRequest()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.DeleteAttachmentItem(It.IsAny<DeleteAttachmentItemModel>())).Throws(new Exception());
            attachmentController.Setup((x) => x.BadRequest());
            //act
            var result = attachmentController.Object.Delete(null);
            //assert
            attachmentController.Verify(x => x.BadRequest(), Times.Once());
        }
        [Test(Description = "Delete")]
        public void Delete_NormalBehaviour_ReturnBadRequest()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.DeleteAttachmentItem(It.IsAny<DeleteAttachmentItemModel>()));
            attachmentController.Setup((x) => x.Ok());
            //act
            var result = attachmentController.Object.Upload(new UploadAttachmentItemModel());
            //assert
            attachmentController.Verify(x => x.Ok(), Times.Once());
        }
        #endregion

        #region GetInfo
        [Test(Description = "GetInfo")]
        public void GetInfo_ReturnNull_ReturnNotFound()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.GetAttachmentItem(It.IsAny<AttachmentItemKeyModel>())).Returns((AttachmentItem)null);
            attachmentController.Setup((x) => x.NotFound());
            //act
            var result = attachmentController.Object.GetInfo(null);
            //assert
            attachmentController.Verify(x => x.NotFound(), Times.Once());
        }
        [Test(Description = "GetInfo")]
        public void GetInfo_ThrowException_ReturnNotFound()
        {
            //arrange
            attachmentBusiness.Setup((x) => x.GetAttachmentItem(It.IsAny<AttachmentItemKeyModel>())).Throws(new Exception());
            attachmentController.Setup((x) => x.BadRequest());
            //act
            var result = attachmentController.Object.GetInfo(null);
            //assert
            attachmentController.Verify(x => x.BadRequest(), Times.Once());
        }
        [Test(Description = "GetInfo")]
        public void GetInfo_ReturnValidValue_ReturnOk()
        {
            //arrange
            var resultModel = new AttachmentItem();
            attachmentBusiness.Setup((x) => x.GetAttachmentItem(It.IsAny<AttachmentItemKeyModel>())).Returns(resultModel);
            attachmentController.Setup((x) => x.Ok(resultModel));
            //act
            var result = attachmentController.Object.GetInfo(null);
            //assert
            attachmentController.Verify(x => x.Ok(resultModel));
        } 
        #endregion
    }
}