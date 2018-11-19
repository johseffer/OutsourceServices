using ServiçosExternos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiçosExternos.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Dashboard
        public ActionResult Index()
        {
            var mediaValorFornecedores = db.Service.GroupBy(d => new { d.Fornecedor.Name, d.ServiceType })
                .Select(x => new MediaFornecedorAux { Fornecedor = x.FirstOrDefault().Fornecedor.Name, Tipo = x.FirstOrDefault().ServiceType, Average = x.Average(y => y.Value) }).OrderBy(x => x.Fornecedor).ToList();

            var topClientes = db.Service.GroupBy(d => new { d.Cliente.Name, d.Date.Value.Month })
                .Select(x => new TopClienteAux { Cliente = x.FirstOrDefault().Cliente.Name, Mes = x.FirstOrDefault().Date.Value.Month, Total = x.Sum(y => y.Value) }).OrderByDescending(x => new { x.Total, x.Mes }).ToList();

            var listaTop3ClientesPorMes = new List<TopClienteAux>();
            var listaFornecedoresInativos = new List<FornecedorInativoAux>();

            topClientes.ForEach(x => x.NomeMes = GetMonthName(new DateTime().AddMonths(x.Mes - 1)));


            for (int i = 1; i <= 12; i++)
            {
                var listaTopClientesMes = topClientes.Where(x => x.Mes == i).OrderByDescending(x => x.Total).ToList();

                if (listaTopClientesMes.Count > 0)
                {
                    listaTop3ClientesPorMes.Add(listaTopClientesMes[0]);

                    if (listaTopClientesMes.Count > 1)
                        listaTop3ClientesPorMes.Add(listaTopClientesMes[1]);

                    if (listaTopClientesMes.Count > 2)
                        listaTop3ClientesPorMes.Add(listaTopClientesMes[2]);
                }
                else
                {
                    listaTop3ClientesPorMes.Add(new TopClienteAux { Cliente = "Sem dados no mês", NomeMes = GetMonthName(new DateTime().AddMonths(i - 1)) });
                }

                var fornecedoreInativosMes = db.Fornecedor
                    .Where(s => !db.Service.Any(x => x.Fornecedor.Id == s.Id && x.Date.Value.Month == i)).ToList();

                if (fornecedoreInativosMes.Count == 0)
                {
                    listaFornecedoresInativos.Add(new FornecedorInativoAux() { Mes = i, NomeMes = GetMonthName(new DateTime().AddMonths(i - 1)), Fornecedor = "Nenhum fornecedor ficou inativo no mês." });
                }
                else
                {
                    listaFornecedoresInativos.AddRange(fornecedoreInativosMes.Select(c => new FornecedorInativoAux() { Mes = i, NomeMes = GetMonthName(new DateTime().AddMonths(i - 1)), Fornecedor = c.Name }));
                }
            }



            return View(new DashboardAux
            {
                ListaTop3ClientesPorMes = listaTop3ClientesPorMes,
                ListaValoresMediosFornecedores = mediaValorFornecedores,
                ListaFornecedoresInativos = listaFornecedoresInativos
            });
        }

        public string GetMonthName(DateTime date)
        {
            return date.ToString("MMMM");
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public class DashboardAux
        {
            public List<TopClienteAux> ListaTop3ClientesPorMes { get; set; }
            public List<FornecedorInativoAux> ListaFornecedoresInativos { get; set; }
            public List<MediaFornecedorAux> ListaValoresMediosFornecedores { get; set; }
        }

        public class TopClienteAux
        {
            public string Cliente { get; set; }
            public int Mes { get; set; }
            public string NomeMes { get; set; }
            public decimal Total { get; set; }
        }

        public class FornecedorInativoAux
        {
            public string Fornecedor { get; set; }
            public int Mes { get; set; }
            public string NomeMes { get; set; }
        }

        public class MediaFornecedorAux
        {
            public string Fornecedor { get; set; }
            public string Tipo { get; set; }
            public decimal Average { get; set; }
        }
    }
}
