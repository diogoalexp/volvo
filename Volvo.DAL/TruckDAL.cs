﻿using Microsoft.EntityFrameworkCore;
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
            Truck t = _truckContext.Truck.Add(truck).Entity;
            _truckContext.SaveChanges();
            return t;
        }

        public bool delete(int id)
        {
            Truck truck = _truckContext.Truck.Find(id);
            if (truck == null)
                return true;
            _truckContext.Truck.Remove(truck);
            _truckContext.SaveChanges();
            return true;
        }

        public Truck update(Truck truck)
        {
            Truck t = _truckContext.Truck.Find(truck.Id);
            if (truck == null)
                return null;

            t.Id = truck.Id;
            t.Name = truck.Name;
            t.Value = truck.Value;
            t.Date = truck.Date;
            t.Model_id = truck.Model_id;
            _truckContext.SaveChanges();
            return truck;
        }

    }
}
