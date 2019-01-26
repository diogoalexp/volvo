using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volvo.Domain
{
    public class Truck
    {
        private int id;
        private string name;
        private decimal value;
        private DateTime date;
        //private Model model;
        private int model_id;

        public Truck() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Value { get => value; set => this.value = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Model_id { get => model_id; set => model_id = value; }

        //public Model Model { get => model; set => model = value; }
    }
}