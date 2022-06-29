using Online.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Teacher model)
        {
            var db = new OnlineSchoolEntities();
            var tc = (from t in db.Teachers
                      where t.Username.Equals(model.Username)
                      && t.Password.Equals(model.Password)
                      select t).SingleOrDefault();
            if (tc != null)
            {
                Session["logged_user"] = tc.Id;
                return RedirectToAction("Homepage", "Teacher");
            }
            TempData["msg"] = "User Does not exist";
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Teacher ts)
        {
            var db = new OnlineSchoolEntities();

            Teacher t = new Teacher();
            {
                t.Name = ts.Name;
                t.FatherName = ts.FatherName;
                t.Mobile = ts.Mobile;
                t.DateOfBirth = ts.DateOfBirth;
                t.JoinDate = DateTime.Today;
                t.Username = ts.Username;
                t.Password = ts.Password;
            }
            if (ModelState.IsValid)
            {
                db.Teachers.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index", "Teacher");
            }

            return View();
        }
        public ActionResult Homepage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject(Course c)
        {
            var db = new OnlineSchoolEntities();

            Course co = new Course();
            co.Name = c.Name;
            co.Details = c.Details;
            co.Price = c.Price;
            co.StudentCapacity = c.StudentCapacity;

            if (ModelState.IsValid)
            {
                db.Courses.Add(co);
                db.SaveChanges();
                return RedirectToAction("CourseList");
            }
            return View();
        }
        public ActionResult CourseList(){
            var db = new OnlineSchoolEntities();
            

            return View(db.Courses.ToList());
            
        }
        public ActionResult Edit(Course c, int id)
        {
            var db = new OnlineSchoolEntities();
            var course = (from s in db.Courses
                           where s.Id == id
                           select s).FirstOrDefault();
            course.Name = c.Name;
            course.Details = c.Details;
            course.Price = c.Price;
            course.StudentCapacity = c.StudentCapacity;            
            db.SaveChanges();
            return RedirectToAction("CourseList");

            //return View(db.Courses.ToList());

        }
        public ActionResult Delete(int id)
        {
            var db = new OnlineSchoolEntities();
            var course = (from s in db.Courses where s.Id == id select s).SingleOrDefault();
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("CourseList");
        }
    }
}