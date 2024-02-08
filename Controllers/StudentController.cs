using CRUDUsingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace CRUDUsingWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7278/api/StudentAPI/";
        private HttpClient client= new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Studentss> students = new List<Studentss>();
            HttpResponseMessage response =  client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                string result=response.Content.ReadAsStringAsync().Result;
                var data =JsonConvert.DeserializeObject<List<Studentss>>(result);
                if(data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Studentss std)
        {
            string data= JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Student Added..";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Studentss std = new Studentss();
            HttpResponseMessage response = client.GetAsync(url+id).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Studentss>(result);
                if (data != null)
                {
                    std = data;
                }

            }
            return View(std);
        }
        public IActionResult Edit(Studentss std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url+std.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Update_message"] = "Student Updated..";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Studentss std = new Studentss();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Studentss>(result);
                if (data != null)
                {
                    std = data;
                }

            }
            return View(std);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Studentss std = new Studentss();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Studentss>(result);
                if (data != null)
                {
                    std = data;
                }

            }
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeteteConfirmed(int id)
        {
            ;
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["delete_message"] = "Student Deleted..";
                return RedirectToAction("Index");



            }
            return View();
        }
    }
}
