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
    public class CategoryController : Controller
    {
        // GET: Category
        public async Task<ActionResult> CategoryAsync()
        {
            List<CategoryModel> consignor = new List<CategoryModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/Category/GetCategory"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    consignor = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);

                }
            }
            return View(consignor);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateCategory(Models.CategoryModel category)
        {
            if (ModelState.IsValid)
            {
               
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44335/api/Category/CreateCategory", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryModel>(apiResponse);

                    }
                }

                
                return RedirectToAction("CategoryAsync");
            }

            return View();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> EditCategory(int id)
        {
            Models.CategoryModel category = new CategoryModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/CategoryID/GetCategoryID?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<CategoryModel>(apiResponse);

                }
            }
            return View(category);
        }


        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> EditCategory(Models.CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://localhost:44335/api/Category/UpdateCategory", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryModel>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("CategoryAsync");
            }
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> DeleteCategory(int id)
        {
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.DeleteAsync("https://localhost:44335/api/Category/DeleteCategory?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }

            return RedirectToAction("CategoryAsync");
        }
    }
}