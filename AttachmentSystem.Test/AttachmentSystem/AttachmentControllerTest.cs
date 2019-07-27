using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Controllers;
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

        //[Test]
        //[TestCase(null, null, null)]
        //public void GetAttachmentId_PassNull_GetException(string entity, string field, int? id)
        //{
        //    attachmentController.Setup((x) =>  x.BadRequest());
        //    var result = attachmentController.Object.GetAttachmentId(entity, field, id);
        //    attachmentController.Verify(x => x.BadRequest(), Times.Once());
        //}
    }
}