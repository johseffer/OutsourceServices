using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiçosExternos.Models;

namespace ServiçosExternos.Controllers
{
    [Authorize]
    public class ApplicationUserFornecedorController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: ApplicationUserFornecedor
        public ActionResult Index()
        {
            var result = db.ApplicationUserFornecedors.Include(s => s.ApplicationUser).Include(s => s.Fornecedor);
            return View(result.ToList());
        }

        // GET: ApplicationUserFornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUserFornecedor applicationUserFornecedor = db.ApplicationUserFornecedors.Find(id);
            if (applicationUserFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(applicationUserFornecedor);
        }

        // GET: ApplicationUserFornecedor/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Name");
            return View();
        }

        // POST: ApplicationUserFornecedor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationUser,ApplicationUserId,Fornecedor,FornecedorId")] ApplicationUserFornecedor applicationUserFornecedor)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationUserFornecedors.Add(applicationUserFornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Name", applicationUserFornecedor.ApplicationUserId);
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Name", applicationUserFornecedor.FornecedorId);

            return View(applicationUserFornecedor);
        }

        // GET: ApplicationUserFornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUserFornecedor applicationUserFornecedor = db.ApplicationUserFornecedors.Find(id);
            if (applicationUserFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(applicationUserFornecedor);
        }

        // POST: ApplicationUserFornecedor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Bairro,Cidade,Estado")] ApplicationUserFornecedor applicationUserFornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUserFornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUserFornecedor);
        }

        // GET: ApplicationUserFornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUserFornecedor applicationUserFornecedor = db.ApplicationUserFornecedors.Find(id);
            if (applicationUserFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(applicationUserFornecedor);
        }

        // POST: ApplicationUserFornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationUserFornecedor applicationUserFornecedor = db.ApplicationUserFornecedors.Find(id);
            db.ApplicationUserFornecedors.Remove(applicationUserFornecedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
