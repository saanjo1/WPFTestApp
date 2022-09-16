using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppv1.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string BarCode { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
