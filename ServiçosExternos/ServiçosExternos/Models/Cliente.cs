using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiçosExternos.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}