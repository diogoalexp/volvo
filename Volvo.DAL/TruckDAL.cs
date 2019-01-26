using System;
using System.Collections.Generic;
using Volvo.DAL.Interface;
using Volvo.Domain;

namespace Volvo.DAL
{
    public class TruckDAL : ITruckDAL
    {
        public Truck get(int id) {
            return new Truck() { Id = 0, Name = "CAMINHAO"  };
        }

        public List<Truck> getAll()
        {
            List<Truck> list = new List<Truck>();
            list.Add(new Truck() { Id = 1, Name = "CAMINHAO" });
            list.Add(new Truck() { Id = 2, Name = "CAMINHA2" });

            return list;
        }

        public Truck add(Truck truck)
        {
            return new Truck() { Id = 0, Name = "CAMINHAO" };
        }

        public bool delete(Truck truck)
        {
            return true;
        }

        public Truck update(Truck truck)
        {
            ;
            return new Truck() { Id = 0, Name = "CAMINHAO" };
        }

    }
}
