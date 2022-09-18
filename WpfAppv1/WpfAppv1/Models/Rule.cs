﻿using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Rule
    {
        public Rule()
        {
            RuleItems = new HashSet<RuleItem>();
            Taxes = new HashSet<Taxis>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsExecuted { get; set; }
        public bool Active { get; set; }
        public string? Type { get; set; }

        public virtual ICollection<RuleItem> RuleItems { get; set; }

        public virtual ICollection<Taxis> Taxes { get; set; }
    }
}
