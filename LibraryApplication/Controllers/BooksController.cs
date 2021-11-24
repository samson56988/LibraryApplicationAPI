using LibraryApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryApplication.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public async Task <ActionResult> Books()
        {
            List<Books> books = new List<Books>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/Books/GetBooks"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Books>>(apiResponse);

                }
            }
            return View(books);
        }

        public async Task<ActionResult> CreateBooks()
        {
            List<Models.CategoryModel> category = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/Populatecategory/PopulateCategory"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);
                    ViewBag.Category = category;
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBooks(Books book)
        {
            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44335/api/Books/CreateBook", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        book = JsonConvert.DeserializeObject<Books>(apiResponse);

                    }
                }


                return RedirectToAction("Books");
            }

            return View();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> EditBooks(int id)
        {
            List<Models.CategoryModel> category = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/Populatecategory/PopulateCategory"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);
                    ViewBag.Category = category;
                }
            }
            Models.Books book = new Books();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/BookID/GetBookID?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Books>(apiResponse);

                }
            }
            return View(book);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> EditBooks(Models.Books books)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(books), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://localhost:44335/api/Books/UpdateBook", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<Books>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("Books");
            }
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> DeleteBooks(int id)
        {
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.DeleteAsync("https://localhost:44335/api/Books/DeleteBook?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }

            return RedirectToAction("Books");
        }

    }
}