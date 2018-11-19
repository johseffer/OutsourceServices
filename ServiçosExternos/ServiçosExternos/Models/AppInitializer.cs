using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServiçosExternos.Models
{
    public class AppInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var clientes = new List<Cliente>
            {
                new Cliente{ Name="Cliente 1", Bairro = "Centro", Cidade = "Jaraguá do Sul", Estado="Santa Catarina"},
                new Cliente{ Name="Cliente 2", Bairro = "Centro", Cidade = "Jaraguá do Sul", Estado="Santa Catarina"}
            };

            clientes.ForEach(s => context.Cliente.Add(s));
            context.SaveChanges();

            var fornecedores = new List<Fornecedor>
            {
                new Fornecedor{ Name="Fornecedor 1"},
                new Fornecedor{ Name="Fornecedor 2"}
            };
            fornecedores.ForEach(s => context.Fornecedor.Add(s));
            context.SaveChanges();

        }
    }

}