using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using AttachmentCore.Configuration;
using AttachmentCore.Common.Contracts;

namespace Tests
{
    [TestFixture]
    public class AttachmentServiceCollectionExtensionsTest
    {
        Mock<IAttachmentBusiness> attachmentBusiness;
        IServiceCollection services;

        //[SetUp]
        //public void Setup()
        //{
        //    attachmentBusiness = new Mock<IAttachmentBusiness>();
        //    attachmentBusiness.Setup(x => x.GetAttachmentId("", "", "")).Returns(new IRISAES.AttachmentModule.Models.AttachmentModel { });
        //    services = new ServiceCollection();
        //}
        //[Test]
        //public void AddAttachment_AddAttachmentBisiness_NotNull()
        //{
        //    //  Arrange
        //    //  Act
        //    services.AddAttachment((o) =>
        //    {
        //        o.BusinessProviderFactory = () => { return attachmentBusiness.Object; };
        //    });

        //    //  Assert
        //    var serviceProvider = services.BuildServiceProvider();
        //    var business = serviceProvider.GetService<IAttachmentBusiness>();
        //    Assert.IsNotNull(business, "Business object has value");
        //}
        [Test]
        public void AddAttachment_PassNullValue_GettingException()
        {
            //  Arrange
            //  Act
            //  Assert
            var serviceProvider = services.BuildServiceProvider();
            var business = serviceProvider.GetService<IAttachmentBusiness>();
            Assert.Throws<ArgumentNullException>(() => services.AddAttachment());
        }
    }
}