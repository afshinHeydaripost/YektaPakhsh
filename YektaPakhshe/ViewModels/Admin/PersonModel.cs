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
    public class PersonItemViewModel : GeneralModel
    {
        [Display(Name = "نام")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; }

        [Display(Name = "کد تجاری")]
        [MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string EconomicCode { get; set; }


        [Display(Name = "تاریخ تولد")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string BirthDate { get; set; }
        [Display(Name = "کد ملی")]
        [MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string NationalityCode { get; set; }
        [Display(Name = "کد ثبت")]
        [MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string RegisterationCode { get; set; }
        [Display(Name = "نوع مالکیت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int OwnerShipTypeId { get; set; }
        [Display(Name = "مالیات پذیر")]
        public bool Taxable { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(1000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; }
        [Display(Name = "شناسه")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Reference { get; set; }

        public bool Disabled { get; set; }
    }
    public class PersonViewModel : GeneralModel
    {
        public string UserId { get; set; }
        public string UserTitle { get; set; }
        public string OwnerShipTypeTitle { get; set; }
    }
    public class OwnerShipTypeViewModel : GeneralModel
    {
    }
}
