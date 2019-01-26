using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volvo.Domain;

namespace Volvo.DAL.Interface
{
    public interface ITruckDAL
    {
        Truck get(int id);
        List<Truck> getAll();
        Truck add(Truck truck);
        bool delete(Truck truck);
        Truck update(Truck truck);
    }
}
