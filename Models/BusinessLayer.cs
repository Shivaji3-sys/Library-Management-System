using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Models
{
    public class BusinessLayer
    {
        DataLayer _dl = new DataLayer();

        internal void AddBook(Book bb)
        {
            _dl.AddBook(bb);
        }


        internal void AddStudent(StudentClass sc)
        {
            _dl.AddStudent(sc);
        }

        internal List<Book> ViewAllBook()
        {
            DataTable dt = _dl.GetAllbook();
            Book b = new Book();
            List<Book> ALLBookList = new List<Book>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Book bbb = new Book();
                    bbb.BookId = Convert.ToInt32(dt.Rows[i]["BookId"].ToString());
                    bbb.BookName = dt.Rows[i]["BookName"].ToString();
                    bbb.AuthorName = dt.Rows[i]["AuthorName"].ToString();
                    bbb.BookPublication = dt.Rows[i]["BookPublication"].ToString();
                    bbb.BookPrice = dt.Rows[i]["BookPrice"].ToString();
                    bbb.BookQuantity = Convert.ToInt32(dt.Rows[i]["BookQuantity"].ToString());
                    ALLBookList.Add(bbb);
                }
            }
            return ALLBookList;
        }

        internal void DeleteS(int id)
        {
            _dl.DeleteS(id);
        }

        internal List<SelectListItem> BookList()
        {
            DataTable dt = _dl.GetAllbook();
            List<SelectListItem> BookList = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SelectListItem ilt = new SelectListItem();
                ilt.Text = dt.Rows[i]["BookName"].ToString();
                ilt.Value = dt.Rows[i]["BookId"].ToString();
                BookList.Add(ilt);
            }
            return BookList;
        }

        internal void returnBookBYStudent(string IId, string id)
        {
            _dl.returnBookBYStudent(IId, id);
        }

        internal List<StudentClass> GetIssueBook(string id)
        {
           DataTable dt =   _dl.GetIssueBook(id);
            List<StudentClass> ListIssueData = new List<StudentClass>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentClass ss = new StudentClass();
                ss.StudentName = dt.Rows[i]["StudentName"].ToString();
                ss.SelectedBook = dt.Rows[i]["SelectedBook"].ToString();
                ss.EnrollmentNo = dt.Rows[i]["EnrollmentNo"].ToString();
                ss.Department = dt.Rows[i]["Department"].ToString();
                ss.Semester = dt.Rows[i]["Semester"].ToString();
                ss.Email = dt.Rows[i]["Email"].ToString();
                ss.Contact = dt.Rows[i]["Contact"].ToString();
                ss.issueDate = dt.Rows[i]["issueDate"].ToString();
                ListIssueData.Add(ss);
            }
            return ListIssueData;

        }

        internal void saveIssueBookData(StudentClass data)
        {
            _dl.saveIssueBookData(data);
        }
        internal List<StudentClass> getIssueBook()
        {
            DataTable dt = _dl.getIssueBook();
            List<StudentClass> ListIssueData = new List<StudentClass>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentClass ss = new StudentClass();
                ss.StudentName = dt.Rows[i]["StudentName"].ToString();
                ss.SelectedBook = dt.Rows[i]["SelectedBook"].ToString();
                ss.EnrollmentNo = dt.Rows[i]["EnrollmentNo"].ToString();
                ss.Department = dt.Rows[i]["Department"].ToString();
                ss.Semester = dt.Rows[i]["Semester"].ToString();
                ss.Email = dt.Rows[i]["Email"].ToString();
                ss.Contact = dt.Rows[i]["Contact"].ToString();
                ss.issueDate = dt.Rows[i]["issueDate"].ToString();
                ListIssueData.Add(ss);
            }
            return ListIssueData;
        }

        internal List<StudentClass> GetAllStudentData()
        {
            DataTable dt = _dl.getAllStudent();
            List<StudentClass> SC = new List<StudentClass>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentClass ss = new StudentClass();
                ss.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ss.StudentName = dt.Rows[i]["StudentName"].ToString();
                ss.EnrollmentNo = dt.Rows[i]["EnrollmentNo"].ToString();
                ss.Department = dt.Rows[i]["Department"].ToString();
                ss.Semester = dt.Rows[i]["Semester"].ToString();
                ss.Contact = dt.Rows[i]["Contact"].ToString();
                ss.Email = dt.Rows[i]["Email"].ToString();
                SC.Add(ss);
            }
            return SC;
        }

        internal StudentClass getStudentDataByID(string id)
        {
            DataTable dt = _dl.getStudentDataByID(id);
            StudentClass ss = new StudentClass();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ss.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ss.StudentName = dt.Rows[i]["StudentName"].ToString();
                ss.EnrollmentNo = dt.Rows[i]["EnrollmentNo"].ToString();
                ss.Department = dt.Rows[i]["Department"].ToString();
                ss.Semester = dt.Rows[i]["Semester"].ToString();
                ss.Contact = dt.Rows[i]["Contact"].ToString();
                ss.Email = dt.Rows[i]["Email"].ToString();
            }
            return ss;
        }

        internal void BookDelete(int id)
        {
            _dl.BookDelete(id);
        }

        internal Book getUpdateBookByID(int id)
        {
            DataTable dt = _dl.getUpdateBookByID(id);
            Book BB = new Book();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BB.BookId = Convert.ToInt32(dt.Rows[i]["BookId"].ToString());
                BB.BookName = dt.Rows[i]["BookName"].ToString();
                BB.AuthorName = dt.Rows[i]["AuthorName"].ToString();
                BB.BookPublication = dt.Rows[i]["BookPublication"].ToString();
                BB.BookPrice = dt.Rows[i]["BookPrice"].ToString();
                BB.BookQuantity = Convert.ToInt32(dt.Rows[i]["BookQuantity"].ToString());
            }
            return BB;
        }
        internal void setUpdateBookByID(Book bB)
        {
            _dl.setUpdateBookByID(bB);
        }
    }
}