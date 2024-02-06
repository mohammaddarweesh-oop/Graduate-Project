using alhadaproject.Models;
using alhadaProject.Models;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace alhadaProject.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpController(ApplicationDbContext context)
        {
            _context = context;
        }
        [NonAction]
        public bool isLegal()
        {
            if (HttpContext.Session.GetString("id") == null) return false;
            if (HttpContext.Session.GetString("userType") != "Emp") return false;

            return true;
        }
        public IActionResult MyProfile()
        {
            if (isLegal()==false) return RedirectToAction("Index","User");  // HTTPGET
            int id = int.Parse(HttpContext.Session.GetString("id"));
            var rec = _context.Employees.Find(id);
            return View(rec);
        }

        public IActionResult ChangePassword()
        {
            if (isLegal() == false) return RedirectToAction("Index", "User");
            return View();
        }


        public IActionResult Index()
        {
            if (isLegal() == false) return RedirectToAction("Index", "User");
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


        #region "States"

        public IActionResult AddEstate1()
        {
            if (isLegal() == false) return RedirectToAction("Index", "User");
            return View();
        }

        [HttpGet]
        public IActionResult AddEstate2()
        {
            if (isLegal() == false) return RedirectToAction("Index", "User");
            List<string> year = new List<string>();

            for (int i = 1980; i <= 2024; i++)
            {
                year.Add(i.ToString());
            }

            List<string> num = new List<string>();

            for (int i = 0; i <= 20; i++)
            {
                num.Add(i.ToString());
            }

            ViewBag.year = year;
            ViewBag.num = num;
            ViewBag.source = new List<string> { "فيسبوك", "السوق المفتوح", "مواقع عقارية", "غير ذلك" };
            ViewBag.city = new List<string> { "عمان" };
            ViewBag.region = new List<string> { "خلدا", "عرقوب خلدا", "مرج الحمام", "صويلح" };
            ViewBag.category = new List<string> { "شقة", "شقة مع روف", "بيت مستقل", "شقة طابقية", "دوبلكس", "شبه فيلا", "شقة مفروشة" };
            ViewBag.stateType = new List<string> { "بيع", "ايجار", "بيع أو ايجار" };
            ViewBag.StateStatus = new List<string> { "فارغ", "مفروش" };
            ViewBag.floor = new List<string> { "أرضي", "أول", "ثاني", "ثالث", "رابع", "تسوية" };





            return View();
        }

        [HttpPost]
        public IActionResult AddEstate2(State state)
        {

            string mainPath = "no_image.jpg";

            int id = int.Parse(HttpContext.Session.GetString("id"));
            state.EmpNo = id;

            state.PromoNotes = state.Notes;

            var file = HttpContext.Request.Form.Files;
            if (file.Count > 0)
            {
                mainPath = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine("wwwroot/", "uploads", mainPath), FileMode.Create);
                file[0].CopyTo(fileStream);
                state.Photo = mainPath;
            }
            else if (state.Photo == null && state.Id == 0)
            {
                state.Photo = "no_image.jpg";
            }
            else
            {
                state.Photo = state.Photo;
            }



            if (ModelState.IsValid)
            {
                _context.Add(state);
                _context.SaveChanges();


                int stateID = _context.States.AsNoTracking().Max(tbl => tbl.Id);

                if (file.Count > 0)
                {
                    for (int i = 0; i < file.Count; i++)
                    {
                        mainPath = Guid.NewGuid().ToString() + Path.GetExtension(file[i].FileName);
                        var fileStream = new FileStream(Path.Combine("wwwroot/", "uploads", mainPath), FileMode.Create);
                        file[i].CopyTo(fileStream);
                        state.Photo = mainPath;


                        StateImage model = new StateImage();
                        model.estateImage = mainPath;
                        model.StateId = stateID;

                        _context.Add(model);
                        _context.SaveChanges();
                    }
                }


                return RedirectToAction("Index");
            }

            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                ViewBag.error = errors.ToString();


                List<string> year = new List<string>();

                for (int i = 1980; i <= 2024; i++)
                {
                    year.Add(i.ToString());
                }

                List<string> num = new List<string>();

                for (int i = 0; i <= 20; i++)
                {
                    num.Add(i.ToString());
                }

                ViewBag.year = year;
                ViewBag.num = num;
                ViewBag.source = new List<string> { "فيسبوك", "السوق المفتوح", "مواقع عقارية", "غير ذلك" };
                ViewBag.city = new List<string> { "عمان" };
                ViewBag.region = new List<string> { "خلدا", "عرقوب خلدا", "مرج الحمام", "صويلح" };
                ViewBag.category = new List<string> { "شقة", "شقة مع روف", "بيت مستقل", "شقة طابقية", "دوبلكس", "شبه فيلا", "شقة مفروشة" };
                ViewBag.stateType = new List<string> { "بيع", "ايجار", "بيع أو ايجار" };
                ViewBag.StateStatus = new List<string> { "فارغ", "مفروش" };
                ViewBag.floor = new List<string> { "أرضي", "أول", "ثاني", "ثالث", "رابع", "تسوية" };
                return View(state);
            }



        }

        [HttpGet]
        public IActionResult EditState(int id)
        {
            if (isLegal() == false) return RedirectToAction("Index", "User");
            List<string> year = new List<string>();

            for (int i = 1980; i <= 2024; i++)
            {
                year.Add(i.ToString());
            }

            List<string> num = new List<string>();

            for (int i = 0; i <= 20; i++)
            {
                num.Add(i.ToString());
            }

            ViewBag.year = year;
            ViewBag.num = num;
            ViewBag.source = new List<string> { "فيسبوك", "السوق المفتوح", "مواقع عقارية", "غير ذلك" };
            ViewBag.city = new List<string> { "عمان" };
            ViewBag.region = new List<string> { "خلدا", "عرقوب خلدا", "مرج الحمام", "صويلح" };
            ViewBag.category = new List<string> { "شقة", "شقة مع روف", "بيت مستقل", "شقة طابقية", "دوبلكس", "شبه فيلا", "شقة مفروشة" };
            ViewBag.stateType = new List<string> { "بيع", "ايجار", "بيع أو ايجار" };
            ViewBag.StateStatus = new List<string> { "فارغ", "مفروش" };
            ViewBag.floor = new List<string> { "أرضي", "أول", "ثاني", "ثالث", "رابع", "تسوية" };

            ViewBag.images = _context.StateImages.Where(tbl => tbl.StateId == id).ToList();
            var rec = _context.States.Find(id);
            return View(rec);
        }



        [HttpPost]
        public IActionResult EditState(State state)
        {
            var rec = _context.States.Where(tbl => tbl.Id == state.Id).AsNoTracking().FirstOrDefault();
            state.Address = rec.Address;
            state.PromoNotes = rec.PromoNotes;
            state.Photo = rec.Photo;


            if (ModelState.IsValid)
            {
                _context.Update(state);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
            ViewBag.error = errors.ToString();

            List<string> year = new List<string>();

            for (int i = 1980; i <= 2024; i++)
            {
                year.Add(i.ToString());
            }

            List<string> num = new List<string>();

            for (int i = 0; i <= 20; i++)
            {
                num.Add(i.ToString());
            }

            ViewBag.year = year;
            ViewBag.num = num;
            ViewBag.source = new List<string> { "فيسبوك", "السوق المفتوح", "مواقع عقارية", "غير ذلك" };
            ViewBag.city = new List<string> { "عمان", "البلقاء", "السلط", "اربد" };
            ViewBag.region = new List<string> { "خلدا", "عرقوب خلدا", "مرج الحمام", "صويلح" };
            ViewBag.category = new List<string> { "شقة", "شقة مع روف", "بيت مستقل", "شقة طابقية", "دوبلكس", "شبه فيلا", "شقة مفروشة" };
            ViewBag.stateType = new List<string> { "بيع", "ايجار", "بيع أو ايجار" };
            ViewBag.StateStatus = new List<string> { "فارغ", "مفروش" };
            ViewBag.floor = new List<string> { "أرضي", "أول", "ثاني", "ثالث", "رابع", "تسوية" };

            return View(state);
        }


        [HttpGet]
        public IActionResult StateDetails(int id)
        {
            if (isLegal() == false) return RedirectToAction("Index", "User");
            StateViewModel stateViewModel = new StateViewModel();
            stateViewModel.state = _context.States.Where(tbl => tbl.Id == id).FirstOrDefault();
            stateViewModel.stateImages = _context.StateImages.Where(tbl => tbl.StateId == id).ToList();
            return View(stateViewModel);
        }

        [HttpGet]
        public IActionResult MyEstate()
        {
            if (isLegal() == false) return RedirectToAction("Index", "User");

            int id = int.Parse(HttpContext.Session.GetString("id"));
            var rec = _context.States.Where(tbl => tbl.EmpNo == id).ToList();
            return View(rec);
        }



        #endregion


        #region "Lands"
        [HttpGet]
        public IActionResult AddLand()
        {



            ViewBag.city = new List<string> { "عمان", "البلقاء", "السلط", "اربد" };
            ViewBag.landDir = new List<string> { "اراضي شرق عمان", "اراضي غرب عمان", "اراضي شمال عمان", "اراضي جنوب عمان" };

            return View();
        }

        [HttpPost]
        public IActionResult AddLand(Land land)
        {
            string mainPath = "no_image.jpg";

            int id = int.Parse(HttpContext.Session.GetString("id"));
            land.EmpNo = id;
            land.StreetNo = 0;


            var file = HttpContext.Request.Form.Files;
            if (file.Count > 0)
            {
                mainPath = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine("wwwroot/", "uploads", mainPath), FileMode.Create);
                file[0].CopyTo(fileStream);
                land.Source = mainPath;
            }
            else if (land.Source == null && land.Id == 0)
            {
                land.Source = "no_image.jpg";
            }
            else
            {
                land.Source = land.Source;
            }



            if (ModelState.IsValid)
            {
                _context.Add(land);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                ViewBag.error = errors.ToString();



                return View(land);
            }


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

        #endregion

        #region "Clients"

        [HttpGet]
        public IActionResult MyClient()
        {
              int id = int.Parse(HttpContext.Session.GetString("id"));




            var r = (from Client in _context.Clients.Where(tbl=>tbl.EmpNo==id).ToList()
                     join Employee in _context.Employees on Client.EmpNo equals Employee.Id
                     select new
                     {
                         Client.Id,
                         Client.Ref,
                         Client.Buy,
                         Client.ClientName,
                         Client.Mobile,
                         Client.Archeive,
                         Client.Interest,
                         Client.AddedDate,
                         Employee.EmpName,

                     }).ToList();

            List<ClientViewModel> list = new List<ClientViewModel>();
            for (int i = 0; i < r.Count; i++)
            {
                list.Add(new ClientViewModel
                {
                    Id = r[i].Id,
                    Ref = r[i].Ref,
                    AddedDate = r[i].AddedDate,
                    Archeive = r[i].Archeive,
                    Buy = r[i].Archeive
                ,
                    ClientName = r[i].ClientName,
                    Mobile = r[i].Mobile,
                    EmpName = r[i].EmpName,
                    Interest = r[i].Interest
                });

            }



            return View(list);
        }

        [HttpPost]
        public IActionResult MyClient(int refs, string cname, string mobile, string interested, string user_id, bool is_archived, bool buy)
        {

            int id = int.Parse(HttpContext.Session.GetString("id"));

            string sql = "select * from Clients where EmpNo ="+ id +"";
            if (refs > 0)
                sql += " and ref = " + refs + "";
            if (cname != null)
                sql += " and ClientName like N'%" + cname + "%'";
            if (mobile != null)
                sql += " and mobile = " + mobile + "";
            if (interested != "0")
                sql += " and Interest like N'%" + cname + "%'";
            
            if (is_archived == true)
                sql += " and Archeive =1 ";
            if (buy == true)
                sql += " and buy =1 ";


            List<Client> recs = _context.Clients.FromSqlRaw(sql).ToList();

            var r = (from Client in recs
                     join Employee in _context.Employees on Client.EmpNo equals Employee.Id
                     select new
                     {
                         Client.Id,
                         Client.Ref,
                         Client.Buy,
                         Client.ClientName,
                         Client.Mobile,
                         Client.Archeive,
                         Client.Interest,
                         Client.AddedDate,
                         Employee.EmpName,

                     }).ToList();

            List<ClientViewModel> list = new List<ClientViewModel>();
            for (int i = 0; i < r.Count; i++)
            {
                list.Add(new ClientViewModel
                {
                    Id = r[i].Id,
                    Ref = r[i].Ref,
                    AddedDate = r[i].AddedDate,
                    Archeive = r[i].Archeive,
                    Buy = r[i].Archeive
                ,
                    ClientName = r[i].ClientName,
                    Mobile = r[i].Mobile,
                    EmpName = r[i].EmpName,
                    Interest = r[i].Interest
                });

            }



            
            return View(list);
        }

        public IActionResult AddClient()
        {
            ViewBag.items = new List<string>() { "مهتم جدا", "مهتم", "غير مهتم" };
            ViewBag.id = HttpContext.Session.GetString("id");
            return View();
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            int id = int.Parse(HttpContext.Session.GetString("id"));

            client.EmpNo = id;

            client.AddedDate = DateTime.Now.ToShortDateString();

            if (ModelState.IsValid)
            {
                _context.Add(client);
                _context.SaveChanges();
                return RedirectToAction("MyClient");
            }

            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                ViewBag.error = errors.ToString();


                return View(client);
            }

            return View();
        }



        public ActionResult EditClient(int id)
        {
            ViewBag.items = new List<string>() { "مهتم جدا", "مهتم", "غير مهتم" };
            var rec = _context.Clients.Find(id);
            return View(rec);
        }
        [HttpPost]
        public ActionResult EditClient(int id, Client client)
        {


            var rec = _context.Clients.Where(tbl => tbl.Id == id).AsNoTracking().FirstOrDefault();
            client.EmpNo = rec.EmpNo;
            client.AddedDate = rec.AddedDate;


            if (ModelState.IsValid)
            {
                _context.Update(client);
                _context.SaveChanges();
                return RedirectToAction("MyClient");
            }

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
            ViewBag.error = errors.ToString();

            ViewBag.items = new List<string>() { "مهتم جدا", "مهتم", "غير مهتم" };
            return View(client);


        }



        public IActionResult ViewClient()
        {
            return View();
        }

        #endregion


 
    }
}
