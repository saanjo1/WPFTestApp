using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class EinvoiceParty
    {
        public EinvoiceParty()
        {
            EinvoiceReceivers = new HashSet<Einvoice>();
            EinvoiceSenders = new HashSet<Einvoice>();
        }

        public Guid Id { get; set; }
        public string RegistrationName { get; set; } = null!;
        public string CompanyId { get; set; } = null!;
        public string? EndpointId { get; set; }
        public string? EndpointIdSchemeId { get; set; }
        public string? PartyIdentificationId { get; set; }
        public string? BusinessBranchName { get; set; }
        public string? PostalAddressStreetName { get; set; }
        public string? PostalAddressCityName { get; set; }
        public string? PostalAddressPostalCode { get; set; }

        public virtual ICollection<Einvoice> EinvoiceReceivers { get; set; }
        public virtual ICollection<Einvoice> EinvoiceSenders { get; set; }
    }
}
