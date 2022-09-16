using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppv1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public string Printer { get; set; }
    }
}
