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
    public class ProductViewModel : GeneralModel
    {
        public string ProductGroupTitle { get; set; }
        public string ProductGroupCode { get; set; }
    }
    public class ProductGroupViewModel : GeneralModel
    {
        public string ParentTitle { get; set; }
        public string ParentCode { get; set; }
    }
}
