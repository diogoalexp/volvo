using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volvo.Domain
{
    public class Truck
    {
        private int id;
        private string name;
        private decimal value;
        private DateTime date;        
        private int model_id;

        public Truck() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]        
        public decimal Value { get => Convert.ToDecimal(value); set => this.value = Convert.ToDecimal(value); }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get => date; set => date = value; }
        public int Model_id { get => model_id; set => model_id = value; }

        
    }
}