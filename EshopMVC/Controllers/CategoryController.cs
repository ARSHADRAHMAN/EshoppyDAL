using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CreateCategory()
        {
            return View();
        }
		[HttpPost]
		public ActionResult CreateCategory(Models.Category catModel)
		{
			EshopDAL.Catogory catSend = new EshopDAL.Catogory();
			catSend.CategoryId = catModel.CategoryId;
			catSend.CategoryName = catModel.CategoryName;
			catSend.CategoryDescription = catModel.CategoryDescription;
			EshopDAL.EshoppyRepository  repo = new EshopDAL.EshoppyRepository();
				repo.AddCategory(catSend);
			return View(catSend);
		}
		public ActionResult ViewAllCategory()
		{
			EshopDAL.EshoppyRepository repo = new EshopDAL.EshoppyRepository();
			List<Models.Category> catModelLst = new List<Models.Category>();
			var catDal = repo.showAllCategory();
			foreach (var cat in catDal)
			{
				Models.Category  catModel= new Models.Category();
				catModel.CategoryId = cat.CategoryId;
				catModel.CategoryDescription = cat.CategoryDescription;
				catModel.CategoryName = cat.CategoryName;
					catModelLst.Add(catModel);
			}
			return View(catModelLst);
		}
		public ActionResult UpdateCategory(string catId)
		{
			EshopDAL.EshoppyRepository repo = new EshopDAL.EshoppyRepository();
			var catDAL = repo.GetCategoryByID(catId);
			Models.Category catModel = new Models.Category();
			catModel.CategoryDescription = catDAL.CategoryDescription;
			catModel.CategoryId = catDAL.CategoryId;
			catModel.CategoryName = catDAL.CategoryName;
			return View(catModel);
		}
		
		[HttpPost]
		public ActionResult UpdateCategory(Models.Category catModel)
		{
			EshopDAL.EshoppyRepository repo = new EshopDAL.EshoppyRepository();
			var catDal = repo.GetCategoryByID(Request.QueryString["catId"]);
			catDal.CategoryDescription = catModel.CategoryDescription;
			catDal.CategoryId = catModel.CategoryId;
			catDal.CategoryName = catModel.CategoryName;
			repo.UpdateCategory(catDal);
			return View(catModel);
		}
		public ActionResult CategoryDetails(string catId)
		{
			EshopDAL.EshoppyRepository repo = new EshopDAL.EshoppyRepository();
			var catDAL = repo.GetCategoryByID(catId);
			Models.Category catModel = new Models.Category();
			catModel.CategoryDescription = catDAL.CategoryDescription;
			catModel.CategoryId = catDAL.CategoryId;
			catModel.CategoryName = catDAL.CategoryName;
			return View(catModel);
		}


	}
}