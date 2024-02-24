using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Admin
{
    internal class PreInvoiceModel
    {
    }
    public class PreInvoiceViewModel : GeneralModel
    {
        [Display(Name = "شماره پیشفاکتور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PreInvoiceNo { get; set; }

        [Display(Name = "تاریخ پیشفاکتور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string PreInvoiceDate { get; set; }

        [Display(Name = "طرف حساب")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int PersonId { get; set; }

        [Display(Name = "درصد تخفیف")]
        public decimal? DiscountRate { get; set; }

        [Display(Name = "تخفیف")]
        public string DiscountPrice { get; set; }

        [Display(Name = "شناسه")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Reference { get; set; }

        public bool Revoked { get; set; }
        public string RevokedDateTime { get; set; }
        public bool Regist { get; set; }
        public string RegistDateTime { get; set; }
        public string TotalNetPrice { get; set; }
        public string TaxPrice { get; set; }
        public string UserId { get; set; }
        public string UserTitle { get; set; }
    }
}
