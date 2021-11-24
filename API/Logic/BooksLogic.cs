using API.Interface;
using API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Logic
{
    public class BooksLogic : IBooks
    {
        public Books AddBooks(Books book)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("Addbook", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Book", book.Title);
                cmd2.Parameters.AddWithValue("@CategoryID", book.categoryID);
                cmd2.ExecuteNonQuery();
                con.Close();
            }

            return book;
        }

        public void DeleteBooks(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("DeleteBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@BookID", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public Books GetBookByID(int id)
        {
            Books book = new Books();
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetBookByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@BookID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    book.Id = Convert.ToInt32(rdr["BookID"].ToString());
                    book.Title = rdr["Book"].ToString();
                    book.Category = rdr["Category"].ToString();
                }
                rdr.Close();
            }

            return book;
        }

        public IEnumerable<Books> GetBooks()
        {
            List<Books> books = new List<Books>();
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Books book = new Books();
                    book.Id = Convert.ToInt32(rdr["BookID"].ToString());
                    book.Category = rdr["Category"].ToString();
                    book.Title = rdr["Book"].ToString();
                    books.Add(book);
                }
                rdr.Close();
            }

            return books;
        }
        

        public List<Category> PopulateCategory()
        {
            List<Category> category = new List<Category>();

            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {

                using (SqlCommand cmd = new SqlCommand("select * from Category", con))
                {
                    cmd.Connection = con;

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            category.Add(
                                new Category
                                {
                                    Id = Convert.ToInt32(sdr["CategoryID"].ToString()),
                                    Name = sdr["Category"].ToString()
                                }

                                );
                        }
                        con.Close();
                    }


                }

                return category;
            }
        }

        public Books UpdateBooks(Books book)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@BookID", book.Id);
                cmd.Parameters.AddWithValue("@Book", book.Title);
                cmd.Parameters.AddWithValue("@CategoryID", book.categoryID);
                cmd.ExecuteNonQuery();

                con.Close();
            }

            return book;
        }
    }
}