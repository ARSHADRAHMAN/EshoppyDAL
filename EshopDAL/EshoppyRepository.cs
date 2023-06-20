using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopDAL
{
    public class EshoppyRepository
    {
        EShoppyDBEntities EShoppyDBEntities = null;
        public EshoppyRepository()
        {
            EShoppyDBEntities = new EShoppyDBEntities();
        }
        public bool AddCustomer(Customer customerDAL)
        {
            EShoppyDBEntities.Customers.Add(customerDAL);

            EShoppyDBEntities.SaveChanges();
            return true;
        }
        public string ValidateUser(string cEmail,string cPass)
        {
            Customer customer = (from c in EShoppyDBEntities.Customers where c.EmailId == cEmail && c.Password == cPass select c).SingleOrDefault();
           
            if(customer==null)
            {
                return string.Empty;
            }
            else
            {
                return customer.EmailId;
            }
          
        }
        public List<Product> ShowAllProducts()
        {
            var prdList = EShoppyDBEntities.Products.ToList();
            return prdList;
         }
		public Customer ViewCustomerDetails(string emailId)
		{
			Customer customer = (from c in EShoppyDBEntities.Customers
								 where c.EmailId == emailId
								 select c).SingleOrDefault();
								return customer;
		}
		public bool Updatecustomer(Customer custDAL)
		{
			Customer existing = (from c in EShoppyDBEntities.Customers
								 where c.EmailId == custDAL.EmailId
								 select c).SingleOrDefault();
			EShoppyDBEntities.SaveChanges();
			EShoppyDBEntities.Customers.Add(existing);
			
			return true;
		}
		public bool AddCategory(Catogory calDAL)
		{
			EShoppyDBEntities.Catogories.Add(calDAL);
			EShoppyDBEntities.SaveChanges();
			return true;
		}
		public List<Catogory> showAllCategory()
		{
			var catlist = EShoppyDBEntities.Catogories.ToList();
			return catlist;
		}
		public Catogory GetCategoryByID(string catID)
		{
			Catogory catDAL = EShoppyDBEntities.Catogories.Find(catID);
			return catDAL;
		}
		public bool UpdateCategory(Catogory catDAL)
		{
			Catogory catExists = EShoppyDBEntities.Catogories.Find(catDAL.CategoryId);
				catExists.CategoryId = catDAL.CategoryId;
			catExists.CategoryId = catDAL.CategoryId;
			catExists.CategoryName = catDAL.CategoryName;
			catExists.CategoryDescription = catDAL.CategoryDescription;
			EShoppyDBEntities.SaveChanges();
			return true;
		}
	}
}
