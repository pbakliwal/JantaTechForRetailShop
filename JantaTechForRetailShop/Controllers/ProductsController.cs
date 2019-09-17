using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using JantaTechForRetailShop.Models;
using JantaTechForRetailShop.VIewModels;
using Mvc;

namespace JantaTechForRetailShop.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            //HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ProductsApi").Result;
            //return View(response.Content.ReadAsAsync<IEnumerable<Product>>().Result);
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            Random random = new Random();
            long barCodeNo = random.Next(10000, 100000000);
            product.BarCodeId= barCodeNo.ToString();
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
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
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,BarCodeId,Colour,Price,Size,Quantity,Brand")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
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
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult GenerateBarCode()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult GenerateBarCode(string barcode)
        //{
        //    Random random = new Random();
        //    long barCodeNo = random.Next(10000,100000000);
        //    barcode = barCodeNo.ToString();
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        using (Bitmap bitMap = new Bitmap(barcode.Length * 40, 80))
        //        {
        //            using (Graphics graphics = Graphics.FromImage(bitMap))
        //            {
        //                Font oFont = new Font("IDAutomationHC39M", 16);
        //                PointF point = new PointF(2f, 2f);
        //                SolidBrush whiteBrush = new SolidBrush(Color.White);
        //                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
        //                SolidBrush blackBrush = new SolidBrush(Color.Black);
        //                graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
        //            }

        //            bitMap.Save(memoryStream, ImageFormat.Jpeg);

        //            ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
        //            ViewBag.BarcodeString = barcode;
        //        }
        //    }

        //    return View();
        //}

        public ActionResult PrintBarCode(Product product)
        {
            string barcode = product.BarCodeId;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (Bitmap bitMap = new Bitmap(barcode.Length * 30, 80))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        Font oFont = new Font("IDAutomationHC39M", 16);
                        PointF point = new PointF(2f, 2f);
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                    }

                    bitMap.Save(memoryStream, ImageFormat.Jpeg);

                    ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    //ViewBag.BarcodeString = barcode;
                }
            }

            return View();
        }

        public ActionResult BillGenerator()
        {
            return View();
        }
        
        public ActionResult GenerateBill(TempProduct tempProduct)
        {
            string barcode = tempProduct.BarCodeId.ToString();
            IEnumerable<Product> products = db.Products.ToList();
            bool flag = false;
            foreach (var item in products)
            {
                if (item.BarCodeId.Equals(barcode))
                {
                        flag = true;
                        tempProduct.BarCodeId = item.BarCodeId;
                        tempProduct.Brand = item.Brand;
                        tempProduct.Category = item.Category;
                        tempProduct.Colour = item.Colour;
                        tempProduct.Price = item.Price;
                        tempProduct.Quantity = item.Quantity;
                        tempProduct.Size = item.Size;
                        tempProduct.QtyPurchased = 0;
                }
            }
            if (flag)
            {
                bool fl = false;
                foreach (var item in db.TempProducts.ToList())
                {
                    if (tempProduct.BarCodeId == item.BarCodeId)
                    {

                        item.QtyPurchased = item.QtyPurchased + 1;
                        item.Quantity = item.Quantity - 1;
                        db.Entry(item).State = EntityState.Modified;
                        fl = true;
                        if (item.Quantity >= 1)
                        {
                            db.SaveChanges();
                        }
                        else
                        {
                            ViewBag.Message = "Insufficient Quantity";
                        }
                        break;
                    }
                }
                if (!fl)
                {
                    if (tempProduct.Quantity >= 1)
                    {
                        tempProduct.Quantity = tempProduct.Quantity - 1;
                        tempProduct.QtyPurchased=tempProduct.QtyPurchased+1;
                        db.TempProducts.Add(tempProduct);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Message = "Insufficient Quantity";
                    }
                    
                }
                    

            }
            else
            {
                ViewBag.Message = "Incorrect Product";
            }
            AllClassViewModel viewModel = new AllClassViewModel
            {
                TempProducts = db.TempProducts.ToList()
            };
            ModelState.Clear();
            return View(viewModel);
        }


        public ActionResult RemoveTemp(int? id)
        {
            TempProduct temp = db.TempProducts.Find(id);
            db.TempProducts.Remove(temp);
            db.SaveChanges();
            AllClassViewModel viewModel = new AllClassViewModel
            {
                TempProducts = db.TempProducts.ToList()
            };
            ModelState.Clear();
            return View("GenerateBill",viewModel);
        }

        public ActionResult AddItem(int? id)
        {
            TempProduct temp = db.TempProducts.Find(id);
            if (temp.Quantity>=1)
            {
                temp.QtyPurchased = temp.QtyPurchased + 1;
                temp.Quantity = temp.Quantity - 1;
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                ViewBag.Message = "Insufficient Quntity";
            }
            
            AllClassViewModel viewModel = new AllClassViewModel
            {
                TempProducts = db.TempProducts.ToList()
            };
            ModelState.Clear();
            return View("GenerateBill", viewModel);
        }

        public ActionResult RemItem(int? id)
        {
            TempProduct temp = db.TempProducts.Find(id);
            temp.QtyPurchased = temp.QtyPurchased - 1;
            temp.Quantity = temp.Quantity + 1;
            if (temp.QtyPurchased <= 1)
            {
                temp.QtyPurchased = 1;
            }
            db.Entry(temp).State = EntityState.Modified;
            db.SaveChanges();
            AllClassViewModel viewModel = new AllClassViewModel
            {
                TempProducts = db.TempProducts.ToList()
            };
            ModelState.Clear();
            return View("GenerateBill", viewModel);
        }

        public ActionResult ConfirmBill()
        {
            return View();
        }

    }

}
