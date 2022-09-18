using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class EinvoiceOrderFormFile
    {
        public EinvoiceOrderFormFile()
        {
            Einvoices = new HashSet<Einvoice>();
        }

        public Guid Id { get; set; }
        public byte[]? GzippedContents { get; set; }

        public virtual ICollection<Einvoice> Einvoices { get; set; }
    }
}
