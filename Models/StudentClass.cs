using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Models
{
    public class StudentClass
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string EnrollmentNo { get; set; }
        public string Department { get; set; }
        public string Semester { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string issueDate { get; set; }
        public string SelectedBook { get; set; }
        public List<SelectListItem> BookList { get;  set; }
    }
}