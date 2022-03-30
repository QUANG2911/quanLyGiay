using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanLyGiay.Models;
namespace quanLyGiay.Controllers
{
    public class TrangchuController : Controller
    {
        private quanLyGiayDBContext db = new quanLyGiayDBContext();
        // GET: Trangchu
        public ActionResult Index()
        {
            ViewBag.SoMauTin = db.Products.Count();
            return View();
        }
    }
}