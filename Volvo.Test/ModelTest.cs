using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using Volvo.DAL;
using Volvo.DAL.Interface;
using Volvo.Domain;
using Volvo.Web.Controllers;

namespace Volvo.Test
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        [TestCategory("Model")]
        public void Index()
        {

            var mock = Substitute.For<IModelDAL>();
            Model sample = new Model() { Id = 0, Name = "Sample" };

            mock.getAll().Returns((new List<Model>(){
                sample
            }));

            var target = new ModelController(mock);

            var result = target.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((List<Model>)result.Model)[0].Name, "Sample");
        }

        [TestMethod]
        [TestCategory("Model")]
        public void Create()
        {

            var mock = Substitute.For<IModelDAL>();

            var target = new ModelController(mock);

            var result = target.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        [TestCategory("Model")]
        public void SaveCreate()
        {

            var mock = Substitute.For<IModelDAL>();
            Model sample = new Model() { Id = 0, Name = "Sample" };

            mock.add(sample).Returns(sample);
            mock.getAll().Returns((new List<Model>(){
                sample
            }));

            var target = new ModelController(mock);

            var result = target.SaveCreate(sample) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((List<Model>)result.Model)[0].Name, "Sample");
        }

        [TestMethod]
        [TestCategory("Model")]
        public void Edit()
        {

            var mock = Substitute.For<IModelDAL>();
            Model sample = new Model() { Id = 0, Name = "Sample" };

            mock.get(0).Returns(sample);

            var target = new ModelController(mock);

            var result = target.Edit(0) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((Model)result.Model).Name, "Sample");
        }

        [TestMethod]
        [TestCategory("Model")]
        public void SaveEdit()
        {

            var mock = Substitute.For<IModelDAL>();
            Model sample = new Model() { Id = 0, Name = "Sample" };

            mock.update(sample).Returns(sample);
            mock.getAll().Returns((new List<Model>(){
                sample
            }));

            var target = new ModelController(mock);

            var result = target.SaveEdit(sample) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((List<Model>)result.Model)[0].Name, "Sample");
        }

        [TestMethod]
        [TestCategory("Model")]
        public void Delete()
        {

            var mock = Substitute.For<IModelDAL>();
            Model sample = new Model() { Id = 0, Name = "Sample" };

            mock.delete(0).Returns(true);
            mock.getAll().Returns((new List<Model>(){
                sample
            }));

            var target = new ModelController(mock);

            var result = target.Delete(0) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((List<Model>)result.Model)[0].Name, "Sample");
        }
    }
}
