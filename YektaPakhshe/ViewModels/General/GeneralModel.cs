using System;
using System.ComponentModel.DataAnnotations;

namespace Helper
{
    public class GeneralModel
    {
        public int? Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "کد")]
        public string Code { get; set; }
    }
}
