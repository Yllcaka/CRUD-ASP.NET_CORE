using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionMVC.Models
{
    public class ProductSearch
    {
        public List<Product> Products { get; set; }
        public SelectList Types { get; set; }
        public string ProductType { get; set; }
        public string SearchString { get; set; }
    }
}
