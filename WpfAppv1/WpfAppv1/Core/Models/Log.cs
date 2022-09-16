using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Log
    {
        public Guid Id { get; set; }
        public string? Action { get; set; }
        public DateTime Created { get; set; }
        public int CreatedYear { get; set; }
    }
}
