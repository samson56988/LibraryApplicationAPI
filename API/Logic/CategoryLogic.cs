using API.Interface;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using API.ConnectionString;
using System.Data.SqlClient;

namespace API.Logic
{
    public class CategoryLogic : ICategory
    {
        public Category AddCategory(Category category)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("AddCategory", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Category", category.Name);
                cmd2.ExecuteNonQuery();
                con.Close();
            }

            return category;
        }

        public void DeleteCategory(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("deletecategory", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categorys = new List<Category>();
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetCategory", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Category category = new Category();
                    category.Id = Convert.ToInt32(rdr["CategoryID"].ToString());
                    category.Name = rdr["Category"].ToString();
                    categorys.Add(category);
                }
                rdr.Close();
            }

            return categorys;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = new Category();
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetCatgoryByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@CategoryID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    category.Id = Convert.ToInt32(rdr["CategoryID"].ToString());
                    category.Name = rdr["Category"].ToString();
                }
                rdr.Close();
            }

            return category;
        }

        public Category UpdateCategory(Category category)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connections.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateCategory", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@CategoryID", category.Id);
                cmd.Parameters.AddWithValue("@Category", category.Name);
                cmd.ExecuteNonQuery();

                con.Close();
            }

            return category;
        }


        
    }
}