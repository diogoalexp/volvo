using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volvo.DAL;
using Volvo.DAL.Interface;
using Volvo.Domain;

namespace Volvo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private TruckContext _truckContext;

        public ValuesController(TruckContext truckContext)
        {
            this._truckContext = truckContext;

        }
        // GET api/values
        [HttpGet]
        public List<Truck> Get()
        {
            ITruckDAL t = new TruckDAL(_truckContext);            
            return t.getAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Truck Get(int id)
        {
            ITruckDAL t = new TruckDAL(_truckContext);
            return t.get(id);
        }

        // POST api/values
        [HttpPost]
        public Truck Post([FromBody]Truck value)
        {
            ITruckDAL t = new TruckDAL(_truckContext);
            return t.add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Truck Put(int id, [FromBody]string value)
        {
            ITruckDAL t = new TruckDAL(_truckContext);
            return t.update(new Truck());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            ITruckDAL t = new TruckDAL(_truckContext);
            return t.delete(new Truck());
        }
    }
}
