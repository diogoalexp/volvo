using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volvo.Domain
{
    [Table("truck")]
    public class Truck
    {
        private int id;
        private string name;
        private decimal value;
        private DateTime date;
        private int yearModel;
        //private int model_id;

        public Truck() { }

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }

        [Column("name")]
        public string Name { get => name; set => name = value; }

        [DataType(dataType: DataType.Currency)]
        [Column("value")]
        public decimal Value { get => value; set => this.value = value; }

        [Display(Name = "Fabrication")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column("date")]
        public DateTime Date { get => date; set => date = value; }

        [Display(Name = "Model Year")]
        [Column("yearModel")]
        public int YearModel { get => yearModel; set => yearModel = value; }

        //public int Model_id { get => model_id; set => model_id = value; }
        [ForeignKey("modelId")]
        [Display(Name = "Model")]
        public virtual Model Model { get; set; }


    }
}