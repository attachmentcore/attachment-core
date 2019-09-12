using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.AttachmentModels;
using AttachmentCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;

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

        [Test]
        [TestCase(null, null, null)]
        public void GetAttachmentId_PassNull_GetException(string entity, string field, string id)
        {
            attachmentController.Setup((x) => x.BadRequest());
            var result = attachmentController.Object.GetAttachmentId(new AttachmentKeyModel {EntityId=id,FieldName=field,EntityName= entity });
            attachmentController.Verify(x => x.BadRequest(), Times.Once());
        }
    }
}