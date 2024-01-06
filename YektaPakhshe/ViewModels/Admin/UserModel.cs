using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModels.Admin
{
	internal class UserModel
	{
	}
	public class ChangePasswordViewModel
	{
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[DataType(DataType.Password)]
		[Display(Name = "کلمه عبور فعلی")]
		public string OldPassword { get; set; }

		[Required(ErrorMessage = "{0} را وارد کنید")]
		[StringLength(100, ErrorMessage = "لطفا {0} را وارد کنید", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "کلمه عبور جدید")]
		public string NewPassword { get; set; }

		[Required(ErrorMessage = "{0} را وارد کنید")]
		[DataType(DataType.Password)]
		[Display(Name = "تکرار کلمه عبور")]
		[Compare("NewPassword", ErrorMessage = "کلمه عبور جدید و تکرار آن باهم مطابقت ندارد")]
		public string ConfirmPassword { get; set; }
	}

}
