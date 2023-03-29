using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Signup2(string name , string? user , string phone, string pass, string repass)

        {
            Regex regex = new Regex(@"^0\d{9}$");
            if (!pass.Equals(repass) || name.Equals("") || user.Equals("") || pass.Equals("") || !regex.IsMatch(phone))
            {
                
                return RedirectPermanent("/Home/Signup");
            }else
            {
                using (var context = new QuanLiQuanAnContext()) {
                    Account acc = context.Accounts.FirstOrDefault(x=>x.Username.Equals(user));
                    if (acc != null)
                    {
                        return RedirectPermanent("/Home/Signup");
                    }
                    else
                    {
                        Account a =  new Account();
                     
                        a.Username = user;
                        a.Password = pass;
                        a.Phone = phone;
                        a.Name = name;
                        a.Role = 3;
                        context.Accounts.Add(a);
                        context.SaveChanges();

                        HttpContext.Session.SetString("acc", System.Text.Json.JsonSerializer.Serialize(a)); 
  
                        return Redirect("/TableFood/List");
                    }
                
                
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}