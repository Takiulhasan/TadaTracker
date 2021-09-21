using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TadaEntries.Models;

namespace TadaEntries.Controllers
{
    public class Employee1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee1
        public ActionResult Index()
        {
            return View(db.Employee1s.OrderByDescending((Employee1 => Employee1.Date)).Take(50).ToList());
        }
        public ActionResult ExportEmployee()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport.rpt"));
            rd.SetDataSource(ListToDataTable(db.Employee1s.ToList()));
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "TADA_HISTORY.pdf");
            }
            catch
            {
                throw;
            }
        }

        private DataTable ListToDataTable<T>(List<T> items)
        {

            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);

                }
                dataTable.Rows.Add(values);

            }
            return dataTable;
        }
        // GET: Employee1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1s.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // GET: Employee1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Name,Travel_Cost,Lunch_Cost,Instrument_Cost,Paid")] Employee1 employee1)
        {
            if (ModelState.IsValid)
            {
                db.Employee1s.Add(employee1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee1);
        }

        // GET: Employee1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1s.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // POST: Employee1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Name,Travel_Cost,Lunch_Cost,Instrument_Cost,Paid")] Employee1 employee1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee1);
        }

        // GET: Employee1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1s.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // POST: Employee1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee1 employee1 = db.Employee1s.Find(id);
            db.Employee1s.Remove(employee1);
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
