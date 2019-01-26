using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volvo.DAL;
using Volvo.DAL.Interface;
using Volvo.Domain;
using Volvo.Web.Models;

namespace Volvo.Web.Controllers
{
    public class TruckController : Controller
    {
        private ITruckDAL _truckDAL;

        public TruckController(ITruckDAL truckDAL)
        {
            this._truckDAL = truckDAL;

        }

        [Route("Truck/Index")]
        public IActionResult Index()
        {
            try
            {
                ViewData["Message"] = "Trucks";

                var viewModel = _truckDAL.getAll();

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Route("Truck/Create")]
        public IActionResult Create()
        {
            try
            {
                ViewData["Message"] = "Add a new Truck.";

                var viewModel = new Truck() { Date = DateTime.Now };

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Route("Truck/SaveCreate")]
        public IActionResult SaveCreate(Truck truck)
        {
            try
            {
                ViewData["Message"] = "The Truck was added.";


                _truckDAL.add(truck);

                var viewModel = _truckDAL.getAll();
                return View("Index", viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        [Route("Truck/Edit")]
        public IActionResult Edit(int id)
        {
            try { 
                ViewData["Message"] = "Edit a Truck.";

                var viewModel = _truckDAL.get(id); ;

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Route("Truck/SaveEdit")]
        public IActionResult SaveEdit(Truck truck)
        {
            try
            {
                ViewData["Message"] = "The Truck was edit.";

                _truckDAL.update(truck);

                var viewModel = _truckDAL.getAll();
                return View("Index", viewModel);
            }
            catch (Exception) {
                return View("Error");
            }
        }

        [Route("Truck/Delete")]
        public IActionResult Delete(int id)
        {
            try { 
                ViewData["Message"] = "The truck was deleted.";
                        
            
                if (_truckDAL.delete(id))
                    ViewData["Message"] = "The truck was deleted.";
                else
                    ViewData["Message"] = "The truck was not deleted.";
            
                var viewModel = _truckDAL.getAll();
                return View("Index", viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


    }
}