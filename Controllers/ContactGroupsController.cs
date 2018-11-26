using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManagement.Models;

namespace ContactManagement.Controllers
{
    public class ContactGroupsController : Controller
    {
        private ContactManagementEntities1 db = new ContactManagementEntities1();

        // GET: ContactGroups
        public ActionResult Index()
        {
            return View(db.ContactGroups.ToList());
        }

        // GET: ContactGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactGroup contactGroup = db.ContactGroups.Find(id);
            if (contactGroup == null)
            {
                return HttpNotFound();
            }
            return View(contactGroup);
        }

        // GET: ContactGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupName")] ContactGroup contactGroup)
        {
            if (ModelState.IsValid)
            {
                db.ContactGroups.Add(contactGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactGroup);
        }

        // GET: ContactGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactGroup contactGroup = db.ContactGroups.Find(id);
            if (contactGroup == null)
            {
                return HttpNotFound();
            }
            return View(contactGroup);
        }

        // POST: ContactGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupName")] ContactGroup contactGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactGroup);
        }

        // GET: ContactGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactGroup contactGroup = db.ContactGroups.Find(id);
            if (contactGroup == null)
            {
                return HttpNotFound();
            }
            return View(contactGroup);
        }

        // POST: ContactGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactGroup contactGroup = db.ContactGroups.Find(id);
            db.ContactGroups.Remove(contactGroup);
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
