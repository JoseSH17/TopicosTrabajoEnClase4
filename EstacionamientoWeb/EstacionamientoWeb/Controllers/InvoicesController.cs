using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstacionamientoWeb.Models;

namespace EstacionamientoWeb.Controllers
{
    [Authorize(Roles = "Operario")]
    public class InvoicesController : Controller
    {
        private ProjectDB db = new ProjectDB();
        
        // GET: Invoices
        public ActionResult Index()
        {
            List<Vehicle> Carx = db.Vehicles.Where(v => v.Brand != "").ToList();
            ViewBag.Cars = Carx;

            

            if (Carx.Count > 0)
            {
                return View(db.Invoices.ToList());
            }
            else
            {
                return View();
            }
        }

        public ActionResult ShowInvoices(int VehicleId)
        {

            ViewBag.Invoices = db.Invoices.Where(v => v.VehicleId == VehicleId).ToList();

            return View();
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create(int VehicleId, string Brand, string Model, string Style, int Year)
        {
            Vehicle car = new Vehicle();
            car.VehicleId = VehicleId;
            car.Brand = Brand;
            car.Model = Model;
            car.Style = Style;
            car.Year = Year;
            ViewBag.Vehicle = car;
            Invoice inv = new Invoice();
            inv.Date = DateTime.Now;
            inv.Tax = 13;
            switch (Style)
            {
                case "SEDAN":
                    {
                        inv.Maintenance = 50000;
                        inv.CostByStyle = 10000;
                        inv.Profit = (inv.Maintenance + (inv.Maintenance * (inv.Tax / 100))) - (inv.CostByStyle);
                        inv.Total = inv.Maintenance + (inv.Maintenance * (inv.Tax / 100));
                        break;
                    }
                case "PICKUP":
                    {
                        inv.Maintenance = 60000;
                        inv.CostByStyle = 15000;
                        inv.Profit = (inv.Maintenance + (inv.Maintenance * (inv.Tax / 100))) - (inv.CostByStyle);
                        inv.Total = inv.Maintenance + (inv.Maintenance * (inv.Tax / 100));
                        break;
                    }
                case "SUV":
                    {
                        inv.Maintenance = 70000;
                        inv.CostByStyle = 20000;
                        inv.Profit = (inv.Maintenance + (inv.Maintenance * (inv.Tax / 100))) - (inv.CostByStyle);
                        inv.Total = inv.Maintenance + (inv.Maintenance * (inv.Tax / 100));
                        break;
                    }
            }
            return View(inv);
        }

        // POST: Invoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceId,VehicleId,Date,Maintenance,Tax,CostByStyle,Profit,Total")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceId,VehicleId,Date,Maintenance,Tax,CostByStyle,Profit,Total")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
