using CustomersWebDemo.DbAccess;
using CustomersWebDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CustomersWebDemo.Controllers
{
    public class CustomerController : Controller
    {

        private CustomerEntitiesDbContext _db;


        public CustomerController()
        {
            this._db = new CustomerEntitiesDbContext();

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
          
        }



        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult Filter(string nameFilter, string emailFilter,
            string locationFilter, int? typeFilter, int page)
        {
            // take customers that are not deleted
            var query = _db.Customers.Where(f => f.FlagDeleted == 0); 

            // аpply filters
            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(f => f.CustomerName.Contains(nameFilter));
            }

            if (!string.IsNullOrEmpty(emailFilter))
            {
                query = query.Where(f => f.Email.Contains(emailFilter));
            }

            if (!string.IsNullOrEmpty(locationFilter))
            {
                query = query.Where(f => f.Location.Contains(locationFilter));
            }

            if (typeFilter != null)
            {
                query = query.Where(f => f.CustomerType == (CustomerTypeEnum)typeFilter);
            }

            // get page and count info
            int pageSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["pageSize"]);
            int itemCount = query.Count();

            // return 1 page of filtered data
            var data = query.OrderBy(a => a.CustomerID)
                .Skip(page * pageSize).Take(pageSize).ToList();

            // populate view data variables

            ViewData["itemCount"] = itemCount;
            ViewData["currentPage"] = page;

            return PartialView(data);
        }

        public ActionResult Create()
        {
            ModelState.Clear();
            return View("CreateEdit", new Customer());
        }
        
        public ActionResult Edit(int id)
        {
            ModelState.Clear();
            return View("CreateEdit", _db.Customers.Find(id));
        }



        public ActionResult CreateEdit(Customer c)
        {
            if (ModelState.IsValid)
            {

                if (c.CustomerID <= 0)   // new customer
                {
                    _db.Customers.Add(c);
                }
                else // existing customer
                {
                    _db.Entry(c).State = EntityState.Modified;
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c);
        }




        public ActionResult Details(int id)
        {
            
            var customer = _db.Customers.Find(id);
            return View(customer);

        }




        public ActionResult Delete(int id)
        {
            var customer = _db.Customers.Find(id);
            return View(customer);
        }

       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _db.Customers.Find(id);
            customer.FlagDeleted = 1;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}