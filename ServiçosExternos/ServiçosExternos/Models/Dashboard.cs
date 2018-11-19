using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServiçosExternos.Models
{
    public class Dashboard
    {
        [NotMapped]
        public ICollection<Service> Services { get; set; }

        [NotMapped]
        public ICollection<Fornecedor> FornecedoresInativos { get; set; }

        [NotMapped]
        public ICollection<Service> ServicesAverage { get; set; }
    }
}