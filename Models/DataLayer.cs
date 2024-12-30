using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class DataLayer
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Con"].ToString();
        //Book
        public void AddBook(Book bb)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "insert into tbl_Book values ('" + bb.BookName + "','" + bb.AuthorName + "','" + bb.BookPublication + "','" + bb.BookPrice + "','" + bb.BookQuantity + "','" + new DateTime() + "','" + 1 + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable GetAllbook()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select * from tbl_Book where isActive = 1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        internal DataTable getUpdateBookByID(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select * from tbl_Book where BookId='" + id + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        internal void BookDelete(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "update tbl_Book set isActive=0 where BookId = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void returnBookBYStudent(string IId, string id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "DELETE FROM tbl_IssueBookDetails where Id='"+IId+ "'and EnrollmentNo='"+id+"' ";
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal DataTable GetIssueBook(string id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select IB.id ,IB.EnrollmentNo,IB.StudentName,IB.Department,IB.Semester,IB.Contact,IB.Email,tbl_Book.BookName as SelectedBook,IB.IssueDate from tbl_IssueBookDetails as IB  join tbl_Book on tbl_Book.BookId= IB.Id where IB.EnrollmentNo = '" + id+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        internal void saveIssueBookData(StudentClass sc)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "insert into tbl_IssueBookDetails values ('" + sc.EnrollmentNo + "','" + sc.StudentName + "','" + sc.Department + "','" + sc.Semester + "','" + sc.Contact + "','" + sc.Email + "','"+sc.SelectedBook+"','" + new DateTime() + "','" + 1 + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal DataTable getIssueBook()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select IB.id , IB.EnrollmentNo,IB.StudentName,IB.Department,IB.Semester,IB.Contact,IB.Email,tbl_Book.BookName as SelectedBook,IB.IssueDate from tbl_IssueBookDetails as IB  join tbl_Book on tbl_Book.BookId= IB.Id";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        internal void setUpdateBookByID(Book bB)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "update tbl_Book set BookName='" + bB.BookName + "', AuthorName='" + bB.AuthorName + "', BookPublication='" + bB.BookPublication + "',BookPrice='" + bB + "',BookQuantity='" + bB.BookQuantity + "'where BookId='" + bB.BookId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal DataTable getStudentDataByID(string id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select * from tbl_Students where EnrollmentNo = '" + id+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        //Student
        public void AddStudent(StudentClass sc)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "insert into tbl_Students values ('" + sc.StudentName + "','" + sc.EnrollmentNo + "','" + sc.Department + "','" + sc.Semester + "','" + sc.Contact + "','" + sc.Email + "','" + new DateTime() + "','" + 1 + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable getAllStudent()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select * from tbl_Students where isActive=1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        internal void DeleteS(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "update tbl_Students set isActive=0 where Id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}