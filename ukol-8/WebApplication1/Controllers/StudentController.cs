using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : BaseController
    {
        public ActionResult All()
        {
            List<Student> students = Ctx.Students.ToList();
            ViewBag.Blekeke = "tralala";
            return View(students);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student s = Ctx.Students.FirstOrDefault(p => p.Id == id);
            if (s!=null)
            {
                return View(s);
            } else
            {
                return new HttpNotFoundResult("Student not found");
            }
        }

        [HttpPost]
        public ActionResult Edit(Student studentEdited)
        {
            Student s = Ctx.Students.FirstOrDefault(p => p.Id == studentEdited.Id);
            if (s != null)
            {
                s.Name = studentEdited.Name;
                s.Surname = studentEdited.Surname;
                s.Rocnik = studentEdited.Rocnik;
                Ctx.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return new HttpNotFoundResult("Student not found");
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student s = Ctx.Students.FirstOrDefault(p => p.Id == id);
            if (s != null)
            {
                return View(s);
            }
            else
            {
                return new HttpNotFoundResult("Student not found");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Student s = Ctx.Students.FirstOrDefault(p => p.Id == id);
            if (s != null)
            {
                Ctx.Students.Remove(s);
                Ctx.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return new HttpNotFoundResult("Student not found");
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student newStudent)
        {

            if (ModelState.IsValid)
            {
                Ctx.Students.Add(newStudent);
                Ctx.SaveChanges();

                return RedirectToAction("All");
            }
            else
            {
                return View(newStudent);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student s = Ctx.Students.FirstOrDefault(p => p.Id == id);
            if (s != null)
            {
                return View(s);
            }
            else
            {
                return new HttpNotFoundResult("Student not found");
            }
        }
    }
}