using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SubjectController : BaseController
    {
        public ActionResult All()
        {
            List<Subject> subjects = Ctx.Subjects.ToList();
            ViewBag.Blekeke = "tralala";
            return View(subjects);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Subject s = Ctx.Subjects.FirstOrDefault(p => p.Id == id);
            if (s != null)
            {
                return View(s);
            }
            else
            {
                return new HttpNotFoundResult("Subject not found");
            }
        }

        [HttpPost]
        public ActionResult Edit(Subject subjectEdited)
        {
            Subject s = Ctx.Subjects.FirstOrDefault(p => p.Id == subjectEdited.Id);
            if (s != null)
            {
                s.Name = subjectEdited.Name;
                s.Abbrev = subjectEdited.Abbrev;
                s.Department = subjectEdited.Department;
                Ctx.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return new HttpNotFoundResult("Subject not found");
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject s = Ctx.Subjects.FirstOrDefault(p => p.Id == id);
            if (s != null)
            {
                return View(s);
            }
            else
            {
                return new HttpNotFoundResult("Subject not found");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Subject s = Ctx.Subjects.FirstOrDefault(p => p.Id == id);
            if (s != null)
            {
                Ctx.Subjects.Remove(s);
                Ctx.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return new HttpNotFoundResult("Subject not found");
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Subject newSubject)
        {

            if (ModelState.IsValid)
            {
                Ctx.Subjects.Add(newSubject);
                Ctx.SaveChanges();

                return RedirectToAction("All");
            }
            else
            {
                return View(newSubject);
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject s = Ctx.Subjects.FirstOrDefault(p => p.Id == id);
            if (s != null)
            {
                return View(s);
            }
            else
            {
                return new HttpNotFoundResult("Subject not found");
            }
        }
    }
}