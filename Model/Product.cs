using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Model
{
    [Table(name: "product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
