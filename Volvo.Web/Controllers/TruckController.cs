using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volvo.DAL;
using Volvo.DAL.Interface;
using Volvo.Domain;

namespace Volvo.Web.Controllers
{
    public class TruckController : Controller
    {
        private TruckContext _truckContext;
        private ModelContext _modelContext;

        public TruckController(TruckContext truckContext, ModelContext modelContext)
        {
            this._truckContext = truckContext;
            this._modelContext = modelContext;

        }

        [Route("Truck/Index")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Trucks";

            ITruckDAL t = new TruckDAL(_truckContext);
            var viewModel = t.getAll();

            return View(viewModel);
        }

        [Route("Truck/Create")]
        public IActionResult Create()
        {
            ViewData["Message"] = "Add a new Truck.";

            var viewModel = new Truck() { Date = DateTime.Now};

            return View(viewModel);
        }

        [Route("Truck/SaveCreate")]
        public IActionResult SaveCreate(Truck truck)
        {
            ViewData["Message"] = "The Truck was added.";
            ITruckDAL t = new TruckDAL(_truckContext);


            t.add(truck);

            var viewModel = t.getAll();
            return View("Index", viewModel);
        }

        [Route("Truck/Edit")]
        public IActionResult Edit(int id)
        {
            ViewData["Message"] = "Edit a Truck.";
            ITruckDAL t = new TruckDAL(_truckContext);
           

            var viewModel = t.get(id); ;

            return View(viewModel);
        }

        [Route("Truck/SaveEdit")]
        public IActionResult SaveEdit(Truck truck)
        {
            ViewData["Message"] = "The Truck was edit.";
            ITruckDAL t = new TruckDAL(_truckContext);


            t.update(truck);

            var viewModel = t.getAll();
            return View("Index", viewModel);
        }

        [Route("Truck/Delete")]
        public IActionResult Delete(int id)
        {
            ViewData["Message"] = "The truck was deleted.";

            ITruckDAL t = new TruckDAL(_truckContext);
            
            if (t.delete(id))
                ViewData["Message"] = "The truck was deleted.";
            else
                ViewData["Message"] = "The truck was not deleted.";
            
            var viewModel = t.getAll();
            return View("Index", viewModel);
        }
    }
}