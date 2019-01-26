using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.DAL.Interface;
using Volvo.Domain;

namespace Volvo.DAL
{
    public class TruckContext : DbContext
    {
        public DbSet<Truck> Truck { get; set; }
        //public DbSet<Model> Model { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSqlLocalDB;Database=volvo;Trusted_connection=true");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Truck>()
        //        .ToTable("truck");
        //    modelBuilder.Entity<Truck>()
        //        .HasKey(p => p.Id);
        //}

        public TruckContext(DbContextOptions<TruckContext> options)
            : base(options)
        { }
    }

    public class TruckDAL : ITruckDAL
    {
        private TruckContext _truckContext;

        public TruckDAL (TruckContext truckContext)
        {
            this._truckContext = truckContext;
        }

        public Truck get(int id) {
            Truck truck = _truckContext.Truck.FindAsync(id).GetAwaiter().GetResult();
            return truck;
        }

        public List<Truck> getAll()
        {
            List<Truck> list =  _truckContext.Truck.ToListAsync().GetAwaiter().GetResult();
            return list;
        }

        public Truck add(Truck truck)
        {
            //using (var db = new TruckContext())
            //{
            //    db.Truck.Add(new Truck() {  });
            //    db.SaveChanges();
            //}
            return new Truck() {  };
        }

        public bool delete(Truck truck)
        {
            return true;
        }

        public Truck update(Truck truck)
        {            
            return new Truck() { };
        }

    }
}
