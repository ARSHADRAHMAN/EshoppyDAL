using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Controllers
{
    public class CustomerController : Controller
    {
        EshopDAL.EshoppyRepository repo = null;
        // GET: Customer
        [HttpGet]
        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomer(Models.Customer custModel)
        {
            EshopDAL.Customer custSend = new EshopDAL.Customer();
            custSend.CustomerId = custModel.CustomerId;
            custSend.CustomerName = custModel.CustomerName;
            custSend.Address = custModel.Address;
            custSend.City = custModel.City;
            custSend.Country = custModel.Country;
            custSend.DeliveryAddress = custModel.DeliveryAddress;
            custSend.EmailId = custModel.EmailId;
            custSend.Password = custModel.Password;
                repo = new EshopDAL.EshoppyRepository();
            if(repo.AddCustomer(custSend))
            {
                ViewBag.Message = "Registered";
            }
            else
            {
                ViewBag.Message = "Error";

            }
            return View();
        }
        public ActionResult LoginCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCustomer(FormCollection fc)
        {
            repo = new EshopDAL.EshoppyRepository() ;
            string emailId = repo.ValidateUser(fc[0].ToString(), fc[1].ToString());
        if (emailId == null || emailId == string.Empty)
            {
                ViewBag.Message = "Login Failed";
            }
            else {
                Session["CustEmail"] = emailId;
               return RedirectToAction("ShowAllProds", "Product");
                // ViewBag.Message = "Login Success";
            }

             return View();

        }
        public ActionResult logout()
        {
            Session.Clear();
            return View("LoginCustomer");
        }
	public ActionResult ViewCustomerProfile()
		{
			repo = new EshopDAL.EshoppyRepository();
			var customerDel = repo.ViewCustomerDetails(Session["custEmail"].ToString());
			Models.Customer customerModel = new Models.Customer();
			customerModel.CustomerId = customerDel.CustomerId;
			customerModel.CustomerName = customerDel.CustomerName;
			customerModel.Address = customerDel.Address;
			customerModel.City = customerDel.City;
			customerModel.Country = customerDel.Country;
			customerModel.DeliveryAddress = customerDel.DeliveryAddress;
			customerModel.EmailId = customerDel.EmailId;
			customerModel.Password = customerDel.Password;
			return View(customerModel);
		}
		public ActionResult Updatecustomer(string custId)
		{
			repo = new EshopDAL.EshoppyRepository();
			var customerDel = repo.ViewCustomerDetails(custId.ToString());
			Models.Customer customerModel = new Models.Customer();
			customerModel.CustomerId = customerDel.CustomerId;
			customerModel.CustomerName = customerDel.CustomerName;
			customerModel.Address = customerDel.Address;
			customerModel.City = customerDel.City;
			customerModel.Country = customerDel.Country;
			customerModel.DeliveryAddress = customerDel.DeliveryAddress;
			customerModel.EmailId = customerDel.EmailId;
			customerModel.Password = customerDel.Password;
			return View(customerModel);
		}
		[HttpPost]
		public ActionResult UpdateCustomer(Models.Customer customerModel)
		{
			repo = new EshopDAL.EshoppyRepository();
			var customerDel = repo.ViewCustomerDetails(Request.QueryString["custId"].ToString());
		//	Models.Customer customerModel = new Models.Customer();
			customerDel.CustomerId = customerModel.CustomerId;
			customerDel.CustomerName = customerModel.CustomerName;
			customerDel.Address = customerModel.Address;
			customerDel.City = customerModel.City;
			customerDel.Country = customerModel.Country;
			customerDel.DeliveryAddress = customerModel.DeliveryAddress;
			customerDel.EmailId = customerModel.EmailId;
			customerDel.Password = customerModel.Password;
			if(repo.Updatecustomer(customerDel))
			{
				ViewBag.Message = "success";
			}
			else
			{
				ViewBag.Message = "fail";
			}
			return View(customerModel);
		}
		//public Action UnsubscribeCustomer()
		//{
		//	return View();
		//}
		//public ActionResult UnsubscribeCustomer(string emailID)
		//{
		//	repo = new EshopDAL.EshoppyRepository();

		//}


	}
}