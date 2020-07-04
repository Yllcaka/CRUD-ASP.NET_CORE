using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VisionMVC.CustomMethods;

namespace VisionMVC.Models
{

    public class Product
    {
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [MinimumValue(0, ErrorMessage="The amount should be more or equal to zero(0)")]
        public int Amount { get; set; }
        [DataType(DataType.Currency)]
        [MinimumValue(0,notEqual:false, ErrorMessage = "Should be a valid price (over 0)")]
        public double Price { get; set; }
        [DataType(DataType.Date), Display(Name = "Added On")]
        public DateTime AddedOn { get; set; }
    }
}
