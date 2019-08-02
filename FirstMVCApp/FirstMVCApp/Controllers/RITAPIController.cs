using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Mvc;
using System.Web.Util;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Diagnostics;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FirstMVCApp.Controllers
{ 
    public class RITAPIController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult UndergradDegrees()
        {
            return View("UndergradDegrees");
        }

        public ActionResult GraduateDegrees()
        {
            return View("GraduateDegrees");
        }

        public ActionResult Map() {
            return View("Map");
        }

        public ActionResult AboutInfo()
        {
            return View("AboutInfo");
        }
        public ActionResult Minor()
        {
            return View("Minor");
        }

        public ActionResult Employment()
        {
            return View("Employment");
        }

        public ActionResult Research()
        {
            return View("Research");
        }

        public ActionResult Resources()
        {
            return View("Resources");
        }

        public ActionResult People()
        {
            return View("People");
        }


        public async Task<JsonResult> SelectMinor()
        {
            var returnedJSON = await GetMinor();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No location info found")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }

        public async Task<JsonResult> SelectEmployment()
        {
            var returnedJSON = await GetEmployment();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No location info found")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }


        public async Task<JsonResult> SelectLocation()
        {
            var returnedJSON = await GetLocationData();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No location info found")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }

        public async Task<JsonResult> SelectPeople()
        {
            var returnedJSON = await GetPeople();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No location info found")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }

        public async Task<JsonResult> SelectResources()
        {
            var returnedJSON = await GetResources();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No location info found")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }

        public static async Task<Object> GetLocationData() {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                

                HttpResponseMessage response = await client.GetAsync("api/location/", HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var rtnResults = JsonConvert.DeserializeObject(data);
                return rtnResults;
            }
        }

        public static async Task<Object> GetResources()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

               

                HttpResponseMessage response = await client.GetAsync("api/resources/", HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var rtnResults = JsonConvert.DeserializeObject(data);
                return rtnResults;
            }
        }

        public static async Task<Object> GetPeople()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

               

                HttpResponseMessage response = await client.GetAsync("api/people/", HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var rtnResults = JsonConvert.DeserializeObject(data);
                return rtnResults;
            }
        }

        public static async Task<Object> GetMinor()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                

                HttpResponseMessage response = await client.GetAsync("api/minors/", HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var rtnResults = JsonConvert.DeserializeObject(data);
                return rtnResults;
            }
        }

        public static async Task<Object> GetEmployment()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                

                HttpResponseMessage response = await client.GetAsync("api/employment/", HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var rtnResults = JsonConvert.DeserializeObject(data);
                return rtnResults;
            }
        }

        public static async Task<Object> DisplayAbout()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                

                HttpResponseMessage response = await client.GetAsync("api/about/", HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var rtnResults = JsonConvert.DeserializeObject(data);
                return rtnResults;
            }
        }

        public async Task<JsonResult> SelectAbout()
        {
            var returnedJSON = await DisplayAbout();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No Degree Programs found.")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }

        public async Task<JsonResult> SelectResearch()
        {
            var returnedJSON = await GetResearch();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No Degree Programs found.")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }




        public async Task<JsonResult> GetUnderGrad()
        {
            var returnedJSON = await GetUndergradDegrees();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No Degree Programs found.")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }

        public async Task<JsonResult> GetGrad()
        {
            var returnedJSON = await GetGraduateDegrees();
            if (returnedJSON == null)
            {
                return ThrowJsonError(new Exception(String.Format("No Degree Programs found.")));
            }
            Session["returnedJSON"] = returnedJSON;
            return null;
        }

        public static async Task<Object> GetUndergradDegrees()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {

                    HttpResponseMessage response = await client.GetAsync("api/degrees/undergraduate/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var rtnResults = JsonConvert.DeserializeObject(data);
                    return rtnResults;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return "Exception";
                }
            }
        }

        public static async Task<Object> GetGraduateDegrees()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/degrees/graduate/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var rtnResults = JsonConvert.DeserializeObject(data);
                    return rtnResults;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return "Exception";
                }
            }
        }

        public static async Task<Object> GetResearch()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/research/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var rtnResults = JsonConvert.DeserializeObject(data);
                    return rtnResults;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return "Exception";
                }
            }
        }

      
       
        public JsonResult ThrowJsonError(Exception e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            Response.StatusDescription = e.Message;

            return Json(new { Message = e.Message }, JsonRequestBehavior.AllowGet);
        }
    }
}
