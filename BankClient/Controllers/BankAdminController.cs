using BankClient.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BankClient.Controllers
{
    public class BankAdminController : Controller
    {
        // GET: BankAdmin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLogin ad)
        {
            if (!ModelState.IsValid)
            {
                return View(ad); // Return the view with validation errors
            }
            string st = "";
            using (var client = new HttpClient())
            {

                string apiUrl = $"https://localhost:44352/api/BankAdmin?EmployeeId={ad.EmployeeId}&Password={ad.Password}";
                client.BaseAddress = new Uri(apiUrl);
                try
                {
                    var responseTask = client.GetAsync(apiUrl);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readdata = result.Content.ReadAsAsync<string>();
                        readdata.Wait();
                        st = readdata.Result;
                        string firstTwoDigits = ad.EmployeeId.Substring(0, 2);
                        Session["UserId"] = ad.EmployeeId;
                        HttpCookie utype = new HttpCookie("utype");

                        if (firstTwoDigits.Equals("AD"))
                        {

                            Session["type"] = "Admin";
                            return RedirectToAction("AdminServices", "BankAdmin");
                        }
                       

                    }
                    else if (result.StatusCode == HttpStatusCode.BadRequest)
                    {
                        try
                        {
                            // Handle the bad request scenario (e.g., invalid credentials)
                            var readdata = result.Content.ReadAsAsync<string>();
                            readdata.Wait();
                            st = readdata.Result;
                        }
                        catch (AggregateException ae)
                        {
                            // Handle the AggregateException and any other inner exceptions
                            foreach (var innerException in ae.Flatten().InnerExceptions)
                            {
                                // Process each inner exception as needed
                                // For example, log the exception or handle it in a specific way
                                Console.WriteLine("Inner Exception: " + innerException.Message);
                            }

                            // Set a default error message if needed
                            st = "Invalid Credentials";
                        }
                    }
                    else
                    {
                        // Handle other error scenarios (optional)
                        st = "Error: " + result.StatusCode.ToString();
                    }
                }

                catch (HttpRequestException ex)
                {
                    // Handle the case when an exception occurs while making the HTTP request
                    st = "Error: " + ex.Message;
                }
            }
            ViewBag.msg = st;
            return View();
        }

        [TypeAuthorization("Admin")]
        public ActionResult AdminServices()
        {
            return View();
        }

       

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Session["type"] = null;

            return RedirectToAction("Login");
        }
    }


}