using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class OrdersPerDate
    {
        public DateTime Date { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
