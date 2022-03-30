using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using quanLyGiay.Models;

namespace quanLyGiay.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public List<ProductCategory> listpc;

        private quanLyGiayDBContext db = new quanLyGiayDBContext();

        public ProductController()
        {
            listpc = new List<ProductCategory>();

            var list = from p in db.Products
                       from c in db.Categories
                       where p.CatId == c.Id
                       select new
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Img = p.Img,
                           Detail = p.Detail,
                           Number = p.Number,
                           Price = p.Price,
                           Status = p.Status,
                           Create_At = p.Create_At,
                           Updated_At = p.Updated_At,
                           CatName = c.Name,
                       };

            foreach (var p in list)
            {
                ProductCategory pc = new ProductCategory();
                pc.Id = p.Id;
                pc.Name = p.Name;
                pc.Img = p.Img;
                pc.Detail = p.Detail;
                pc.Number = p.Number;
                pc.Price = p.Price;
                pc.Status = p.Status;
                pc.Create_At = p.Create_At;
                pc.Updated_At = p.Updated_At;
                pc.CatName = p.CatName;
                listpc.Add(pc);
            }
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var list = listpc.Where(p => p.Status != 0).ToList();
            return View(list);
        }

        public ActionResult Trash()
        {
            var list = db.Products.Where(p => p.Status == 0).OrderByDescending(m => m.Create_At).ToList();
            return View("Trash", list);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = listpc.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(db.Categories.ToList(), "Id", "Name", 0);
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product product)
        {
            if (ModelState.IsValid)
            {
                
                product.Create_At = DateTime.Now;
              
                product.Updated_At = DateTime.Now;

                var Img = Request.Files["img"];
                string[] FileExtent = { ".jpg", ".png", ".gif" };
                if(Img.ContentLength != 0)
                {
                    if(FileExtent.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {

                        product.Img = Img.FileName;

                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/"), Img.FileName);

                        Img.SaveAs(PathImg);
                    }    
                }    


                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListCat = new SelectList(db.Categories.ToList(), "Id", "Name", 0);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.ListCat = new SelectList(db.Categories.ToList(), "Id", "Name", 0);

            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product product)
        {
            if (ModelState.IsValid)
            {
                product.Updated_At = DateTime.Now;
                var Img = Request.Files["img"];
                string[] FileExtent = { ".jpg", ".png", ".gif" };
                if (Img.ContentLength != 0)
                {
                    if (FileExtent.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        if (product.Img != null)
                        {
                            String DelPath = Path.Combine(Server.MapPath("~/Public/img/"), product.Img);
                            if (System.IO.File.Exists(DelPath))
                            {
                                System.IO.File.Delete(DelPath);
                            }
                        }    

                        product.Img = Img.FileName;
                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/"), Img.FileName);

                        Img.SaveAs(PathImg);
                    }
                }


                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListCat = new SelectList(db.Categories.ToList(), "Id", "Name", 0);
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = listpc.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Trash","Product");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Status(int id)
        {
            Product category = db.Products.Find(id);
            int x = (category.Status == 1) ? 2 : 1;
            category.Status = x;
            category.Updated_At = DateTime.Now;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DelTrash(int id)
        {
            Product category = db.Products.Find(id);
            category.Status = 0;
            category.Updated_At = DateTime.Now;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public ActionResult ReTrash(int id)
        {
            Product category = db.Products.Find(id);
            category.Status = 1;
            category.Updated_At = DateTime.Now;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
