using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using Volvo.DAL;
using Volvo.DAL.Interface;
using Volvo.Domain;
using Volvo.Web.Controllers;
using Volvo.Web.Models;

namespace Volvo.Test
{
    [TestClass]
    public class TruckTest
    {
        [TestMethod]  
        [TestCategory("Truck")]
        public void Index()
        {

            var mock = Substitute.For<ITruckDAL>();
            var mock2 = Substitute.For<IModelDAL>();  
            Truck sample = new Truck() { Id = 0, Name = "Sample", Model_id = 1 };
            Model sample2 = new Model() { Id = 1, Name = "Sample Type" };

            mock.getAll().Returns((new List<Truck>(){
                sample
            }));

            mock2.getAll().Returns((new List<Model>(){
                sample2
            }));

            var target = new TruckController(mock, mock2);

            var result = target.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((List < TruckViewModel >)result.Model)[0].truck.Name, "Sample");
            Assert.AreSame(((List<TruckViewModel>)result.Model)[0].model.Name, "Sample Type");
        }

        [TestMethod]
        [TestCategory("Truck")]
        public void Create()
        {

            var mock = Substitute.For<ITruckDAL>();
            var mock2 = Substitute.For<IModelDAL>();

            var target = new TruckController(mock, mock2);

            var result = target.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        [TestCategory("Truck")]
        public void SaveCreate()
        {

            var mock = Substitute.For<ITruckDAL>();
            var mock2 = Substitute.For<IModelDAL>();
            Truck sample = new Truck() { Id = 0, Name = "Sample", Model_id = 1 };
            Model sample2 = new Model() { Id = 1, Name = "Sample Type" };

            mock.add(sample).Returns(sample);
            mock.getAll().Returns((new List<Truck>(){
                sample
            }));

            mock2.getAll().Returns((new List<Model>(){
                sample2
            }));

            var target = new TruckController(mock, mock2);

            var result = target.SaveCreate(sample) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((List<TruckViewModel>)result.Model)[0].truck.Name, "Sample");
            Assert.AreSame(((List<TruckViewModel>)result.Model)[0].model.Name, "Sample Type");
        }

        [TestMethod]
        [TestCategory("Truck")]
        public void Edit()
        {

            var mock = Substitute.For<ITruckDAL>();
            var mock2 = Substitute.For<IModelDAL>();
            Truck sample = new Truck() { Id = 0, Name = "Sample" };

            mock.get(0).Returns(sample);

            var target = new TruckController(mock, mock2);

            var result = target.Edit(0) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((Truck)result.Model).Name, "Sample");
        }

        [TestMethod]
        [TestCategory("Truck")]
        public void SaveEdit()
        {

            var mock = Substitute.For<ITruckDAL>();
            var mock2 = Substitute.For<IModelDAL>();
            Truck sample = new Truck() { Id = 0, Name = "Sample", Model_id = 1 };
            Model sample2 = new Model() { Id = 1, Name = "Sample Type" };

            mock.update(sample).Returns(sample);
            mock.getAll().Returns((new List<Truck>(){
                sample
            }));

            mock2.getAll().Returns((new List<Model>(){
                sample2
            }));

            var target = new TruckController(mock, mock2);

            var result = target.SaveEdit(sample) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((List<TruckViewModel>)result.Model)[0].truck.Name, "Sample");
            Assert.AreSame(((List<TruckViewModel>)result.Model)[0].model.Name, "Sample Type");
        }

        [TestMethod]
        [TestCategory("Truck")]
        public void Delete()
        {

            var mock = Substitute.For<ITruckDAL>();
            var mock2 = Substitute.For<IModelDAL>();
            Truck sample = new Truck() { Id = 0, Name = "Sample", Model_id = 1 };
            Model sample2 = new Model() { Id = 1, Name = "Sample Type" };

            mock.delete(0).Returns(true);
            mock.getAll().Returns((new List<Truck>(){
                sample
            }));

            mock2.getAll().Returns((new List<Model>(){
                sample2
            }));

            var target = new TruckController(mock, mock2);

            var result = target.Delete(0) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreSame(((List<TruckViewModel>)result.Model)[0].truck.Name, "Sample");
            Assert.AreSame(((List<TruckViewModel>)result.Model)[0].model.Name, "Sample Type");
        }
    }
}
