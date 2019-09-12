using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.IO;
using System;
using AttachmentCore.Configuration;

namespace Tests
{
    [TestFixture]
    public class AttachmentApplicationBuilderExtensionTest
    {
        Mock<IApplicationBuilder> appBuilder;
        [SetUp]
        public void Setup()
        {
            appBuilder = new Mock<IApplicationBuilder>();
        }

        [Test]
        public void UseAttachment_PassNullArgument_GetException()
        {

            Assert.Throws<ArgumentNullException>(() => {
                appBuilder.Object.UseAttachment(null);
            });
        }
    }
}