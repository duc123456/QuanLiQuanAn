using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class TableFoodController : Controller
    {
        public IActionResult List()
        {
            using (var context = new QuanLiQuanAnContext())
            {

                List<TableFood> list = context.TableFoods.ToList();
                ViewBag.list=list;
                string userName = HttpContext.Session.GetString("userName");
                Account acc = context.Accounts.FirstOrDefault(x => x.Username.Equals(userName));
                // use the acc object as needed
                List<Bill> bills = context.Bills.Where(x => x.Phone == acc.Phone && x.Status == 3).ToList();
                ViewBag.bills = bills;



            }
            return View();
        }
        public IActionResult Login(string user , string pass)
        {
            using (var context = new QuanLiQuanAnContext())
            {
                Account acc = context.Accounts.FirstOrDefault(x=>x.Username.Equals(user) && x.Password.Equals(pass));
                HttpContext.Session.SetString("acc", System.Text.Json.JsonSerializer.Serialize(acc));
                if (acc == null)
                {
                    return Redirect("/Home/Index");
                }else
                {
                    HttpContext.Session.SetString("userName", acc.Username);
                    return RedirectToAction("List");
                }

            }
            
            return View();
        }
        public IActionResult DatBan(int id, string phone)
        {
            using (var text = new QuanLiQuanAnContext())
            {
                    
                    
                    Bill bill = new Bill();
               
              
                    bill.IdTable = id;
                    bill.Phone = phone; 
                    bill.DateCheckIn = DateTime.Now;
                    bill.Status = 3;
                    TableFood tb = text.TableFoods.FirstOrDefault(x=>x.Id == id);
                    tb.Status = "Đã đặt";
                    text.Bills.Add(bill);
                    text.SaveChanges();
                    return Redirect("/TableFood/Login");
                    
                
            }
            return View();
        }
    }
}
