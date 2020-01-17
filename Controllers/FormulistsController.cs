using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMap.Models;

namespace GMap.Controllers
{
    public class FormulistsController : Controller
    {
        private Context db = new Context();

        // GET: Formulists
        public ActionResult Index()
        {
            return View(db.MyFormulist.ToList());
        }

        // GET: Formulists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulist formulist = db.MyFormulist.Find(id);
            if (formulist == null)
            {
                return HttpNotFound();
            }
            return View(formulist);
        }

        // GET: Formulists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formulists/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nickname,number,address,lat,lgt,foto")] Formulist formulist)
        {
            if (ModelState.IsValid)
            {
                db.MyFormulist.Add(formulist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formulist);
        }

        // GET: Formulists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulist formulist = db.MyFormulist.Find(id);
            if (formulist == null)
            {
                return HttpNotFound();
            }
            return View(formulist);
        }

        // POST: Formulists/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nickname,number,address,lat,lgt,foto")] Formulist formulist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formulist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formulist);
        }

        // GET: Formulists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulist formulist = db.MyFormulist.Find(id);
            if (formulist == null)
            {
                return HttpNotFound();
            }
            return View(formulist);
        }

        // POST: Formulists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formulist formulist = db.MyFormulist.Find(id);
            db.MyFormulist.Remove(formulist);
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
