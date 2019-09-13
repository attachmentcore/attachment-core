using AttachmentCore.Common.Models.AttachmentModels;
using AttachmentCore.Store.SqlServer.Business;
using AttachmentCore.Store.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class AttachmenBusinessTest
    {
        private Mock<AttachmentDbContext> attachmentDbContext;
        [SetUp]
        public void Setup()
        {
            attachmentDbContext = new Mock<AttachmentDbContext>();
            attachmentDbContext.Setup(x => x.SaveChanges()).Returns(0);

        }

        [Test]
        [TestCase(null, null, null)]
        [TestCase("x", "y", "")]
        [TestCase("x", "", "z")]
        [TestCase("", "y", "z")]
        public void CreateAttachment_Token_PassInvalidArgument_GetException(string entity, string field, string token)
        {
            //arrange
            var options = new DbContextOptionsBuilder<AttachmentDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateAttachment_PassNull_GetException")
                .Options;
            //act
            using (var context = new AttachmentDbContext(options))
            {
                var service = new SqlServerAttachmenBusiness(context);
                Assert.Throws<ArgumentNullException>(() =>
                {
                    //act
                    service.CreateAttachmentTemporarily(new TemporaryAttachmentKeyModel { EntityName = entity, FieldName = field, Token = token });
                });
            }
        }
        [Test]
        public void CreateAttachment_PassData_GetAttachmentModel()
        {
            //arrange
            var options = new DbContextOptionsBuilder<AttachmentDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateAttachment_PassData_GetAttachmentModel")
                .Options;
            //act
            AttachmentModel result;
            using (var context = new AttachmentDbContext(options))
            {
                var service = new SqlServerAttachmenBusiness(context);
                result = service.CreateAttachmentTemporarily(new TemporaryAttachmentKeyModel { EntityName = "x", FieldName = "y", Token = "z" });
            }
            //assert
            Assert.IsNotNull(result);
            using (var context = new AttachmentDbContext(options))
            {
                var item = context.Attachments.SingleOrDefault(x => x.Id == result.AttachmentId);
                Assert.IsNotNull(item);
                Assert.AreEqual("x", item.EntityName);
                Assert.AreEqual("y", item.FieldName);
                Assert.AreEqual("z", item.Token);
                Assert.AreEqual(null, item.EntityId);
            }
        }
        //[Test]
        //[TestCase(null, null, 0)]
        //[TestCase("x", "y", 0)]
        //[TestCase("x", "", 1)]
        //[TestCase("", "y", 1)]
        //public void CreateAttachment_Id_PassInvalidArgument_GetException(string entity, string field, int id)
        //{
        //    //arrange
        //    var options = new DbContextOptionsBuilder<AttachmentDbContext>()
        //        .UseInMemoryDatabase(databaseName: "CreateAttachment_PassNull_GetException")
        //        .Options;
        //    //act
        //    using (var context = new AttachmentDbContext(options))
        //    {
        //        var service = new SqlServerAttachmenBusiness(context);
        //        Assert.Throws<ArgumentNullException>(() =>
        //        {
        //            //act
        //            service.CreateAttachment(entity, field, id);
        //        });
        //    }
        //}
        [Test]
        public void CreateAttachment_Id_PassValidArgument_GetAttachmentModel()
        {
            //arrange
            var options = new DbContextOptionsBuilder<AttachmentDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateAttachment_Id_PassValidArgument_GetAttachmentModel")
                .Options;
            //act
            AttachmentModel result;
            using (var context = new AttachmentDbContext(options))
            {
                var service = new SqlServerAttachmenBusiness(context);
                result = service.CreateAttachment(new AttachmentKeyModel { EntityName = "x", FieldName = "y",  EntityId = "z" });
            }
            //assert
            Assert.IsNotNull(result);
            using (var context = new AttachmentDbContext(options))
            {
                var item = context.Attachments.SingleOrDefault(x => x.Id == result.AttachmentId);
                Assert.IsNotNull(item);
                Assert.AreEqual("x", item.EntityName);
                Assert.AreEqual("y", item.FieldName);
                Assert.AreEqual("z", item.EntityId);
            }
        }
    }
}