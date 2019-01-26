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
    public class ModelController : Controller
    {        
        private IModelDAL _modelDAL;

        public ModelController(IModelDAL modelDAL)
        {
            this._modelDAL = modelDAL;
        }

        [Route("Model/Index")]
        public IActionResult Index()
        {
            try
            {
                ViewData["Message"] = "Models";

                var viewModel = _modelDAL.getAll();

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Route("Model/Create")]
        public IActionResult Create()
        {
            try
            {
                ViewData["Message"] = "Add a new Model.";

                var viewModel = new Model();

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Route("Model/SaveCreate")]
        public IActionResult SaveCreate(Model model)
        {
            try
            {
                ViewData["Message"] = "The Model was added.";

                _modelDAL.add(model);

                var viewModel = _modelDAL.getAll();
                return View("Index", viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        [Route("Model/Edit")]
        public IActionResult Edit(int id)
        {
            try
            {
                ViewData["Message"] = "Edit a Model.";

                var viewModel = _modelDAL.get(id); ;

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Route("Model/SaveEdit")]
        public IActionResult SaveEdit(Model model)
        {
            try
            {
                ViewData["Message"] = "The Model was edit.";

                _modelDAL.update(model);

                var viewModel = _modelDAL.getAll();
                return View("Index", viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Route("Model/Delete")]
        public IActionResult Remove(int id)
        {
            try
            {
                ViewData["Message"] = "The model was deleted.";

                if (_modelDAL.delete(id))
                    ViewData["Message"] = "The model was deleted.";
                else
                    ViewData["Message"] = "The model was not deleted.";

                var viewModel = _modelDAL.getAll();
                return View("Index", viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}