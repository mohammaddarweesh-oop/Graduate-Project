using alhadaproject.Models;
using alhadaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alhadaProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            HomeViewModel model = new HomeViewModel();
            model.carousalState = _context.States.Where(tbl => tbl.Sold == false && tbl.HomePage == true).AsNoTracking().ToList();
            model.states = _context.States.Where(tbl => tbl.Sold == false).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string reference, string category, string city, string region, int roomNo, double fromArea, double toArea, double fromPrice, double toPrice, int fromYear, int toYear, string floor)
        {
            string sql = "select * from states where sold =0 ";
            if (reference != null)
                sql += " and Ref = " + reference + "";
            if (category != "0")
                sql += " and Category = N'" + category + "'";
            if (city != "0")
                sql += " and City = N'" + city + "'";
            if (region != "0")
                sql += " and City = N'" + city + "'";
            if (roomNo > 0)
                sql += " and RoomNo = " + roomNo + "";

            if (fromArea > 0 && toArea > 0)
                sql += " and LandArea between " + fromArea + " and " + toArea + "";
            if (fromPrice > 0 && toPrice > 0)
                sql += " and Price between " + fromPrice + " and " + toPrice + "";
            if (fromYear > 0 && toYear > 0)
                sql += " and Price between " + fromPrice + " and " + toPrice + "";

            if (floor != "0")
                sql += " and Floor = N'" + floor + "'";


            HomeViewModel model = new HomeViewModel();
            model.carousalState = _context.States.Where(tbl => tbl.Sold == false && tbl.HomePage == true).AsNoTracking().ToList();
            model.states = _context.States.FromSqlRaw(sql).ToList();

            return View(model);
        }

        public IActionResult StateDetails(int id)
        {
            StateViewModel stateViewModel = new StateViewModel();
            stateViewModel.state = _context.States.Where(tbl => tbl.Id == id).FirstOrDefault();
            stateViewModel.stateImages = _context.StateImages.Where(tbl => tbl.StateId == id).ToList();
            return View(stateViewModel);
        }



        public IActionResult ViewEstate()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(string FullName , string Email , string Title , string Message  )
        {
            Inbox inbox = new Inbox();
            inbox.Email = Email;
            inbox.Title = Title;
            inbox.Message = Message;
            inbox.FullName = FullName;
            

            _context.Add(inbox);

            _context.SaveChanges();

            return View();
        }




        [HttpGet]
        public IActionResult SearchLand()
        {
            var rec = _context.Lands.ToList();
            return View(rec);
        }

        [HttpPost]
        public IActionResult SearchLand(string refs, string owner, string mobile, bool sold, string city,
            string landDir, string region, string basinName, int landNo, double fromArea, double toArea, double fromPrice, double toPrice)
        {
            string sql = "select * from Lands where 1=1 ";
            if (refs != null)
                sql = sql + " and ref =" + refs + "";
            if (owner != null)
                sql = sql + " and owner like N'%" + owner + "%'";
            if (mobile != null)
                sql = sql + " and mobile =N'" + mobile + "'";
            if (sold == true)
                sql = sql + " and sold =1";
            if (city != "0")
                sql = sql + " and city =N'" + city + "'";
            if (landDir != "0")
                sql = sql + " and landDir =N'" + landDir + "'";

            if (region != null)
                sql = sql + " and region like N'%" + region + "%'";

            if (basinName != null)
                sql = sql + " and basinName like N'%" + basinName + "%'";

            if (landNo > 0)
                sql = sql + " and landNo =" + landNo + "";


            if (fromArea > 0 && toArea > 0)
                sql = sql + " and TotalArea between " + fromArea + " and " + toArea + "";

            if (fromPrice > 0 && toPrice > 0)
                sql = sql + " and price between " + fromPrice + " and " + toPrice + "";

            List<Land> recs = _context.Lands.FromSqlRaw(sql).ToList();

            return View(recs);
        }

        public IActionResult LandDetails(int id)
        {
            var rec = _context.Lands.Find(id);
            return View(rec);
        }



        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser(string email , string password)
        {
            var rec = _context.Employees.Where(tbl=> tbl.Email == email && tbl.Password== password).FirstOrDefault();
            if (rec != null)
            {
                HttpContext.Session.SetString("id", rec.Id.ToString());
                HttpContext.Session.SetString("name", rec.EmpName.ToString());
                HttpContext.Session.SetString("userType", rec.UserType.ToString());

                

                if (rec.UserType =="Admin")
                {
                    return RedirectToAction("index", "Admin");
                }
                else
                {
                    return RedirectToAction("index", "Emp");
                }
            }

            else
            {
                ViewBag.error = "المستخدم غير مخول لدخول النظام";
                return View();
            }
            
        }
    }
}
