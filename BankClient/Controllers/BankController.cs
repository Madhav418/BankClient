using BankClient.Models.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BankClient.Controllers
{
    
    public class BankController : Controller
    {
        public ActionResult Register()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Register(User reg)
        {
            if (ModelState.IsValid)
            {
                return View(reg);

               
            }
            else
            {
                string st = "";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44352/api/Bank");
                    var responseTask = client.PostAsJsonAsync<User>("Bank", reg);
                  

                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readdata = result.Content.ReadAsAsync<string>();
                        readdata.Wait();
                        st = readdata.Result;
                       

                    }
                    else
                    {
                        var readdata = result.Content.ReadAsAsync<string>();
                        readdata.Wait();
                        st = readdata.Result;

                    }
                }
                ViewBag.msg = st;
                return View();
            }  
           

            
           
           
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(login login)
        {

            if (login.rememberMe)
            {
                // Set cookies if "Remember Me" is checked
                Response.Cookies["rememberedUserID"].Value = login.UserID;
                Response.Cookies["rememberedPassword"].Value = login.Password;
                Response.Cookies["rememberedUserID"].Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies["rememberedPassword"].Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies["rememberMe"].Value = "true";
                Response.Cookies["rememberMe"].Expires = DateTime.Now.AddMinutes(10);
            }
            else
            {
                // Clear cookies if "Remember Me" is not checked
                Response.Cookies["rememberedUserID"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["rememberedPassword"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["rememberMe"].Expires = DateTime.Now.AddDays(-1);
            }



            string st = "";
            string Acc="";
            using (var client = new HttpClient())
            {
               
                string apiUrl = $"https://localhost:44352/api/Bank?username={login.UserID}&password={login.Password}";
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
                       
                        Acc=readdata.Result;
                        int AcNo = int.Parse(Acc);


                        
                        string firstDigit = login.UserID.Substring(0, 1);
                        Session["Account"] = AcNo;
                        Session["UserId"] = login.UserID;
                        HttpCookie utype = new HttpCookie("utype");

                        if (firstDigit.Equals("U"))
                        {
                            Session["type"] = "User";

                            return RedirectToAction("Operations", "UserTransactions");

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
                            st = "Account doesnot exist/Invalid Credentials";
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
        
        
        public ActionResult AdminLogin()
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
       

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        [TypeAuthorization("User")]
        public ActionResult FeedBack()
        {

            FeedBackModel model = new FeedBackModel();
            //Set UserId from session if needed



            return View();
        }
        [HttpPost]
        public ActionResult Feedback(FeedBackModel model)
        {
            if (ModelState.IsValid)
            {
                //Your logic for processing feedback

                //Redirect to a success page or return appropriate response
                ViewBag.Message = "Feedback submitted successfully!";
                return View(model);
            }
            else
            {
                //Model is not valid, return the View with validation messages
                return View();
            }
        }



    }
   
}