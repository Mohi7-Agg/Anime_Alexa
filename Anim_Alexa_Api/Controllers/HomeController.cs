using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Anim_Alexa_Api.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Anim_Alexa_Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        static Uri baseUri = new Uri("https://gikg98iqxj.execute-api.us-east-1.amazonaws.com/");

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/getAwsObject")]
        public async Task<JsonResult> GetAWS_resp()
        {
            client.BaseAddress = baseUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("POC");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<object>();
                return Json(data);
            }

            return null;
        }

        [Route("/About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Route("/Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [Route("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
