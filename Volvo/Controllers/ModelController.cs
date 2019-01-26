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
    public class ModelController : Controller
    {
        private IModelDAL _modelDAL;        


        public ModelController(IModelDAL modelDAL)
        {
            this._modelDAL = modelDAL;

        }
        // GET api/values
        [HttpGet]
        public List<Model> Get()
        {                 
            return _modelDAL.getAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Model Get(int id)
        {            
            return _modelDAL.get(id);
        }

        // POST api/values
        [HttpPost]
        public Model Post([FromBody]Model value)
        {            
            return _modelDAL.add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Model Put(int id, [FromBody]string value)
        {            
            return _modelDAL.update(new Model());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _modelDAL.delete(id);
        }
    }
}
