using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyodhyaYatra_Web.Models.Visitor
{
    public class VisitorModel
    {
        public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Mobile { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string DocumentNumber { get; set; }
            public int DocumentTypeId { get; set; }
            public DateTime RegistrationDate { get; set; }
            public DateTime VisitDate { get; set; }
    }
}