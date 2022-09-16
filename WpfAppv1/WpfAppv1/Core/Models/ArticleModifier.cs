using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class ArticleModifier
    {
        public Guid Id { get; set; }
        public Guid? ModifierId { get; set; }
        public Guid? ArticleId { get; set; }
    }
}
