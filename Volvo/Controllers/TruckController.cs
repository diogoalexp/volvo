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
    public class TruckController : Controller
    {
        private ITruckDAL _truckDAL;        


        public TruckController(ITruckDAL truckDAL)
        {
            this._truckDAL = truckDAL;

        }
        // GET api/values
        [HttpGet]
        public List<Truck> Get()
        {                 
            return _truckDAL.getAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Truck Get(int id)
        {            
            return _truckDAL.get(id);
        }

        // POST api/values
        [HttpPost]
        public Truck Post([FromBody]Truck value)
        {            
            return _truckDAL.add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Truck Put(int id, [FromBody]string value)
        {            
            return _truckDAL.update(new Truck());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _truckDAL.delete(id);
        }
    }
}
