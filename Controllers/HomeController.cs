using LibraryManagementSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        BusinessLayer _bl = new BusinessLayer();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book bb)
        {
            _bl.AddBook(bb);
            return View();
        }
        [HttpGet]
        public ActionResult ViewAllBook()
        {
            List<Book> AllBook =  _bl.ViewAllBook();
            ViewBag.AllBook = AllBook;
            return View();
        }
        [HttpGet]
       public ActionResult Update(int id=1)
        {
           Book BB =  _bl.getUpdateBookByID(id);
            return View(BB);
        }
        [HttpPost]
        public ActionResult Update(Book BB)
        {
            _bl.setUpdateBookByID(BB);
            return RedirectToAction("ViewAllBook", "Home");
        }
        public ActionResult Delete(int id)
        {
            _bl.BookDelete(id);
           return RedirectToAction("ViewAllBook", "Home");
        }
        [HttpGet]
        public ActionResult IssueBook()
        {
            StudentClass SCC = new StudentClass();
            List<SelectListItem> BookList = _bl.BookList();
            SCC.BookList = BookList;
            return View(SCC);
        }
        [HttpPost]
        public ActionResult IssueBook(string Id)
        {
            return RedirectToAction("IssueBook", "Home");
        }
        public ActionResult saveIssueBookData(string issueBookData)
        {
            var data = JsonConvert.DeserializeObject<StudentClass>(issueBookData);
            _bl.saveIssueBookData(data);
            return RedirectToAction("IssueBook", "Home");
        }
        public ActionResult AllIssueBook()
        {
          List<StudentClass> ListIssueData =   _bl.getIssueBook();
            ViewBag.ListIssueData = ListIssueData;
            return View();
        }
        public ActionResult ReturnBook()
        {
            return View();
        }
    }
}