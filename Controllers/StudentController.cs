using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        BusinessLayer _bl = new BusinessLayer();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(StudentClass sc)
        {
            _bl.AddStudent(sc);
            return View();
        }
        public ActionResult GetAllStudentData()
        {
            List<StudentClass> StuALLData = _bl.GetAllStudentData();
            ViewBag.StuALLData = StuALLData;
            return View();
        }

        public JsonResult getStudentDataByID(string Id)
        {
            try
            {
                var studentData = _bl.getStudentDataByID(Id);
                return Json(studentData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Log exception here
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Delete(int id)
        {
            _bl.DeleteS(id);
            return RedirectToAction("GetAllStudentData", "Student");
        }

        public ActionResult GetIssueBook(string Id)
        {
            var data = _bl.GetIssueBook(Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult returnBookBYStudent(string IId, string Id)
        {
            _bl.returnBookBYStudent(IId,Id);
            return RedirectToAction("ReturnBook","Student");
        }
    }
}