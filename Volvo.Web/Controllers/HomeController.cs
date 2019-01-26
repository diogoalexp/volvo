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
    public class HomeController : Controller
    {
        private TruckContext _truckContext;
        private ModelContext _modelContext;


        public HomeController(TruckContext truckContext, ModelContext modelContext)
        {
            this._truckContext = truckContext;
            this._modelContext = modelContext;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            ITruckDAL t = new TruckDAL(_truckContext, _modelContext);
            var viewModel =  t.getAll();

            return View(viewModel);            
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
