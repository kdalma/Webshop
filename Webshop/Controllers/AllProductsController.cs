using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Webshop;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class AllProductsController : Controller
    {
        private WebshopDBEntities db = new WebshopDBEntities();

        /// <summary>
        /// list of all products, with category dropdown list
        /// </summary>
        /// <returns>all products</returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var categoryList = db.ProductCategory.Select(c => new Category()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            categoryList.Insert(0, new Category()
            {
                Id = 0,
                Name = "-- Összes kategória --"
            });

            ViewBag.Categories = categoryList;
            
            var allProducts = db.Product.Include(s => s.Size).Include(c => c.ProductCategory).Where(p => p.SizeId == 1);
            return View(await allProducts.ToListAsync());
        }

        /// <summary>
        /// you can get the details of allproducts page
        /// </summary>
        /// <param name="Id">product Id</param>
        /// <returns>a product details page</returns>
        [HttpGet]
        public async Task<ActionResult> Details(int? Id)
        {
            Product product = await db.Product.FindAsync(Id);

            AllProducts allProducts = new AllProducts()
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price,
                AllSizes = db.Size.Select(s => new SizeModel()
                {
                    Id = s.Id,
                    Value = s.Value
                }).ToList()
            };

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(allProducts);
        }

        //POST: Saving datas from details page to cart
        [HttpPost]
        public ActionResult Details (int Id, int SizeId)
        {
            Product productThatWeSearchWith = db.Product.Find(Id);
            Product product = db.Product.Include(p => p.Size).
                Where(p => p.Name == productThatWeSearchWith.Name 
                && p.Description == productThatWeSearchWith.Description 
                && p.SizeId == SizeId).FirstOrDefault();
            
            ((List<Product>)Session["Cart"]).Add(product);

            return RedirectToAction("Index", "AllProducts");
        }

        // GET: AllProducts/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Value");
            return View();
        }

        // POST: AllProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Price,Image,SizeId,ProductCategoryId")] Product allProducts)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(allProducts);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SizeId = new SelectList(db.Size, "Id", "Value", allProducts.SizeId);
            return View(allProducts);
        }

        // GET: AllProducts/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Product.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Value", product.SizeId);
            return View(product);
        }

        // POST: AllProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Price,Image,SizeId,ProductCategoryId")] Product allProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allProducts).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Value", allProducts.SizeId);
            return View(allProducts);
        }

        // GET: AllProducts/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Product.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: AllProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Product.FindAsync(id);
            db.Product.Remove(product);
            await db.SaveChangesAsync();
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


        /// <summary>
        /// POST: Products filtering by product name or description, even by category
        /// </summary>
        /// <param name="searchString">product name or description</param>
        /// <param name="categoryId">the Id of the selected category in the dropdown list</param>
        /// <returns>filtering result</returns>
        [HttpPost]
        public async Task<ActionResult> ProductsFilter(string searchString, int categoryId)
        {
            //make dropdown list from the categories based on the database table
            //insert "all categories" into the list
            var categoryList = db.ProductCategory.Select(c => new Category()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();             

            categoryList.Insert(0, new Category()
            {
                Id = 0,
                Name = "-- Összes kategória --"
            });

            ViewBag.Categories = categoryList;

            //filtering query by excluding duplicates
            var products = db.Product
                .Include(s => s.Size)
                .Include(c => c.ProductCategory)
                .Where(p => p.SizeId == 1);

            if (!String.IsNullOrEmpty(searchString))
                products = products.Where(s => s.Name.Contains(searchString) || s.Description.Contains(searchString));
            
            if (categoryId != 0)
                products = products.Where(p => p.ProductCategoryId == categoryId);

            return View("Index", await products.ToListAsync());
        }
    }
}