﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }
       

        public ActionResult Details(int id)
        {
            var customers=_context.Customers.SingleOrDefault(c => c.ID == id);
            customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
            if (customers == null)
                return HttpNotFound();
            return View(customers);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.ID==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.ID == customer.ID);
                //Mapper.Map(customer,customerInDB);
                customerInDB.Name = customer.Name;
                customerInDB.Dob = customer.Dob;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubSribedToNewsLetter = customer.IsSubSribedToNewsLetter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                MembershipTypes=membershipTypes
            };
            return View("CustomerForm",viewmodel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
    }
}