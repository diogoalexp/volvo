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
        private ModelContext _modelContext;

        public ModelController(ModelContext modelContext)
        {
            this._modelContext = modelContext;
        }

        [Route("Model/Index")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Models";

            IModelDAL t = new ModelDAL(_modelContext);
            var viewModel = t.getAll();

            return View(viewModel);
        }

        [Route("Model/Create")]
        public IActionResult Create()
        {
            ViewData["Message"] = "Add a new Model.";

            var viewModel = new Model();

            return View(viewModel);
        }

        [Route("Model/SaveCreate")]
        public IActionResult SaveCreate(Model model)
        {
            ViewData["Message"] = "The Model was added.";
            IModelDAL t = new ModelDAL(_modelContext);


            t.add(model);

            var viewModel = t.getAll();
            return View("Index", viewModel);
        }

        [Route("Model/Edit")]
        public IActionResult Edit(int id)
        {
            ViewData["Message"] = "Edit a Model.";
            IModelDAL t = new ModelDAL(_modelContext);


            var viewModel = t.get(id); ;

            return View(viewModel);
        }

        [Route("Model/SaveEdit")]
        public IActionResult SaveEdit(Model model)
        {
            ViewData["Message"] = "The Model was edit.";
            IModelDAL t = new ModelDAL(_modelContext);


            t.update(model);

            var viewModel = t.getAll();
            return View("Index", viewModel);
        }

        [Route("Model/Delete")]
        public IActionResult Delete(int id)
        {
            ViewData["Message"] = "The model was deleted.";

            IModelDAL t = new ModelDAL(_modelContext);

            if (t.delete(id))
                ViewData["Message"] = "The model was deleted.";
            else
                ViewData["Message"] = "The model was not deleted.";

            var viewModel = t.getAll();
            return View("Index", viewModel);
        }
    }
}