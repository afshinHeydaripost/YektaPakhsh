using Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModels.Admin
{
	internal class ProductModel
	{
	}
	public class ProductViewModel:GeneralModel
	{
		public string Title { get; set; }
		public string Code { get; set; }
		public string ProductGroupTitle { get; set; }
		public string ProductGroupCode { get; set; }
	}
}
