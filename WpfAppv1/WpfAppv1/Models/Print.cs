﻿using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Print
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
        public DateTime Created { get; set; }
    }
}
