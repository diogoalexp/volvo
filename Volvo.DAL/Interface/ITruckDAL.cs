﻿using System;
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
        bool delete(int id);
        Truck update(Truck truck);
    }
}
