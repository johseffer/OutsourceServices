using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiçosExternos.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}