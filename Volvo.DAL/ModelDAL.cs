using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.DAL.Interface;
using Volvo.Domain;

namespace Volvo.DAL
{
    public class ModelContext : DbContext
    {
        
        public DbSet<Model> Model { get; set; }


        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        { }
    }

    public class ModelDAL : IModelDAL
    {
        private ModelContext _ModelContext;

        public ModelDAL (ModelContext ModelContext)
        {
            this._ModelContext = ModelContext;
        }

        public Model get(int id) {
            Model Model = _ModelContext.Model.FindAsync(id).GetAwaiter().GetResult();
            return Model;
        }

        public List<Model> getAll()
        {
            List<Model> list =  _ModelContext.Model.ToListAsync().GetAwaiter().GetResult();
            return list;
        }

        public Model add(Model model)
        {
            Model t = _ModelContext.Model.Add(model).Entity;
            _ModelContext.SaveChanges();
            return t;
        }

        public bool delete(int id)
        {
            Model Model = _ModelContext.Model.Find(id);
            if (Model == null)
                return true;
            _ModelContext.Model.Remove(Model);
            _ModelContext.SaveChanges();
            return true;
        }

        public Model update(Model model)
        {
            Model m = _ModelContext.Model.Find(model.Id);
            if (model == null)
                return null;

            m.Id = model.Id;
            m.Name = model.Name;
            _ModelContext.SaveChanges();
            return m;
        }

    }
}
