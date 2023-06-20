using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Controllers
{
    public class ProductController : Controller
    {
        EshopDAL.EshoppyRepository respo = null;
        // GET: Product
        public ActionResult ShowAllProds()
        {
            respo = new EshopDAL.EshoppyRepository();
            var listProd = respo.ShowAllProducts();
            List<Models.Product> prdList = new List<Models.Product>();
            foreach (var  prod in listProd)
            {
                Models.Product localProd = new Models.Product();
                localProd.ProductId = prod.ProductId;
                localProd.ProductName = prod.ProductName;
                localProd.ProductPrice = prod.ProductPrice;
                localProd.ProductDescription = prod.ProductDescription;
                localProd.ExistsInStock = prod.ExistsInStock;
                localProd.CategoryId = prod.CategoryId;
                prdList.Add(localProd);

            }
            return View(prdList);
            //return View();
        }
    }
}