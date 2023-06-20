using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EshopMVC.Models
{
    public class Customer
    {
		[Required(ErrorMessage ="ID Please") ]
        public string CustomerId { get; set; }
		[Required(ErrorMessage = "Enter name")]
		[Display (Name="HFull Name")]
		public string CustomerName { get; set; }
		[Required]
		[DisplayName ("Parmant Address")]
		public string Address { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		[DataType (DataType.EmailAddress)]
		public string EmailId { get; set; }
		[Required]
		
		public string Password { get; set; }
		[Required]
		public string DeliveryAddress { get; set; }
    }
}