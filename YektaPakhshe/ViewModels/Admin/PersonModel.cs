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
    internal class PersonModel
    {
    }
    public class PersonViewModel : GeneralModel
    {
        public string UserId { get; set; }
        public string UserTitle { get; set; }
        public string OwnerShipTypeTitle { get; set; }
    }
}
