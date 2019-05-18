using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Volvo.Domain
{
    [Table("Model")]
    public class Model
    {
        private int id;
        private string name;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }

        [Column("name")]
        public string Name { get => name; set => name = value; }
    }
}
