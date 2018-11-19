using ServiçosExternos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ServiçosExternos.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        //private List<Models.Service> reportItems;
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Post");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult GetReport(ServiceAux model)
        {
            try
            {
                IQueryable<Models.Service> result = db.Service;

                if (model.Cliente != null && !String.IsNullOrEmpty(model.Cliente.Name))
                    result = result.Where(x => x.Cliente.Name.Contains(model.Cliente.Name));

                if (!String.IsNullOrEmpty(model.Bairro))
                    result = result.Where(x => x.Cliente.Bairro.ToUpper().Contains(model.Bairro.ToUpper()));

                if (!String.IsNullOrEmpty(model.Cidade))
                    result = result.Where(x => x.Cliente.Cidade.ToUpper().Contains(model.Cidade.ToUpper()));

                if (!String.IsNullOrEmpty(model.Estado))
                    result = result.Where(x => x.Cliente.Estado.ToUpper().Contains(model.Estado.ToUpper()));

                if (!String.IsNullOrEmpty(model.Service))
                    result = result.Where(x => x.ServiceType.ToUpper().Contains(model.Service.ToUpper()));

                if (model.ValorMin > 0)
                    result = result.Where(x => x.Value >= model.ValorMin);

                if (model.ValorMax > 0)
                    result = result.Where(x => x.Value <= model.ValorMax);

                TempData["reportItems"] = result.OrderBy(x => new { x.Date,x.Cliente.Name }).ToList();

                //return View(result.ToList());
                return RedirectToAction("ReportView");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ReportView()
        {
            var reportItems = ((List<Models.Service>)TempData["reportItems"]);
            TempData["reportItems"] = reportItems;
            return View(reportItems);
        }

        public class ServiceAux
        {
            public Cliente Cliente { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string Service { get; set; }
            public decimal ValorMin { get; set; }
            public decimal ValorMax { get; set; }
        }

        public class ReportAux
        {
            public List<Models.Service> Services { get; set; }
        }
    }
}
