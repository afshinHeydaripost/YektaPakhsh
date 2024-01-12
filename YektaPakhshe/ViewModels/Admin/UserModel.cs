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
	internal class UserModel
	{
	}
	public class UserViewModel
	{
		public string? UserId { get; set; }
		[Display(Name = "نام")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد ")]
		public string firstName { get; set; }

		[Display(Name = "نام خانوادگی")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد ")]
		public string LastName { get; set; }

		[Display(Name = "کد ملی")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد ")]
		public string NationalCode { get; set; }

		[Display(Name = "تاریخ تولد")]
		[MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد ")]
		public string? strBirthday { get; set; }



		[Display(Name = "آدرس")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد ")]
		public string Address { get; set; }

		[Display(Name = "شماره موبایل")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد ")]
		public string PhoneNumber { get; set; }
		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد ")]
		[DataType(dataType:DataType.EmailAddress,ErrorMessage ="{0} معتبر نیست")]
		public string Email { get; set; }


		[DataType(DataType.Upload)]
		public IFormFile? UploadedFile { get; set; }
		public string? ProfilePicture { get; set; }
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
