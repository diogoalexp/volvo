using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo.Domain;

namespace Volvo.Web.Models
{
    public class TruckViewModel
    {
        public Truck truck;
        public Model model;
        public IEnumerable<Model> modelos;

        public TruckViewModel (Truck truck, Model model)
        {
            this.truck = truck;
            this.model = model;
        }

        public TruckViewModel(Truck truck, IEnumerable<Model> modelos)
        {
            this.truck = truck;
            this.modelos = modelos;
        }
    }
}
