using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VMOCS.DAL;
using VMOCS.Models;

namespace VMOCS.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext dc = new ApplicationContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Company u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ApplicationContext dc = new ApplicationContext())
                    {
                        var v = dc.Companies.Where(a => a.Username.Equals(u.Username.ToLower()) && a.Password.Equals(u.Password)).FirstOrDefault();
                        if (v != null)
                        {
                            string user = v.Username.ToString();
                            Session["CompanyName"] = v.CompanyName.ToString();
                            Session["LoggedUserID"] = v.UserID.ToString();
                            Session["AccountNumber"] = v.Account.ToString();
                            Session["LoggedUsername"] = user;

                            switch (user)
                            {
                                case "mdxl":
                                    return RedirectToAction("Mdxl");
                                case "threefountainsadmin":
                                    return View("ThreeFountains");
                                case "chesapeake":
                                    return View("Chesapeake");
                                case "admin":
                                    return View("Admin");
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Incorrect username or password. Please check your login and try again.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(e.InnerException.ToString(), "Exception occurred. Please contact support.");
            }
            return View(u);
        }

        public ActionResult Mdxl()
        {
            var numbers = dc.Users.OrderBy(q => q.Name).ToList();
            ViewBag.SelectedNumbers = new SelectList(numbers, "NUMBER", "NAME");

            IQueryable<User> forwards = dc.Users;
            var sql = forwards.ToString();
            return View(forwards.ToList());
        }

        public ActionResult AccountHome()
        {
            if (Session["LoggedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Process()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Process(string notify1, string notify2, string notify3)
        {
            string selectedNumber = Request.Form["SelectedNumbers"].ToString();

            if (notify1 != "" || notify2 != "" || notify3 != "")
            {
                string filename = "1234.txt";
                string appPath = Request.PhysicalApplicationPath;
                string filePath = appPath + @"\" + filename;

                FileInfo info = new FileInfo(filePath);
                using (StreamWriter writer = info.CreateText())
                {
                    writer.WriteLine("amodify om=" + Session["Account"] + " pn1=" + notify1 + " an1=" + notify2 + " an2=" + notify3);
                    writer.WriteLine(" ");
                    writer.Flush();
                    writer.Close();
                }

                //ftpfile("12.182.40.70", @"/" + filename, filePath, "ftp1", "just4george");
                //ftpfile("ftp.silverstatetelecom.com", @"/" + filename, filePath, ConfigurationManager.AppSettings["FtpAccount"].ToString(), ConfigurationManager.AppSettings["FtpPassword"].ToString());

                string message = string.Empty;

                if (notify1 != string.Empty)
                    message = "Successfully Changed Message Delivery Number to " + notify1;

                if (notify2 != string.Empty)
                    message = message + " and 5 minute backup number to " + notify2;

                if (notify3 != string.Empty)
                    message = message + " and 10 minute backup number to " + notify3;

                Session["Message"] = message;
                Session["notify1"] = notify1;
                Session["timestamp"] = DateTime.Now;
            }

            //send mail to do

            return View("AccountHome");
        }

        private void ftpfile(string host, string ftpfilepath, string inputfilepath, string un, string pw)
        {
            try
            {
                string ftphost = host;
                string ftpfullpath = "ftp://" + ftphost + ftpfilepath;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(un, pw);
                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = new FileStream(inputfilepath, FileMode.Open);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
            }
            catch (Exception e)
            {
                ModelState.AddModelError(e.InnerException.ToString(), "Unexpected Error. Please try again.");
            }
        }
    }
}
