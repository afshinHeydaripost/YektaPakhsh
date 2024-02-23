using Helper;
using System;
using System.Collections.Generic;
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
        public string PreInvoiceNo { get; set; }

        public string PreInvoiceDate { get; set; }

        public int PersonId { get; set; }

        public decimal? DiscountRate { get; set; }
        public string DiscountPrice { get; set; }

        public string Reference { get; set; }

        public bool Revoked { get; set; }
        public string RevokedDateTime { get; set; }
        public bool Regist { get; set; }
        public bool RegistDateTime { get; set; }
        public string TotalNetPrice { get; set; }
        public string TaxPrice { get; set; }
        public string UserId { get; set; }
    }
}
