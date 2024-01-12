﻿namespace Repository.Class
{
    public class Message
    {
        //---- User ---
        public const string test = "";
        public const string NotAddAddress = "شما آدرسی ندارید";
        public const string UserAddAddress = "این کاربر آدرس ارسال ندارد";
        public const string InvalidAddress = "آدرس پستی خود را صحیح وارد نمایید";
        public const string InvalidCityAndState = "استان و شهر را به درستی وارد نمایید.";
        public const string SuccessLoading = "اطلاعات با موفیت دریافت شد.";
        public const string ChooseImgFile = "لطفا تصویری را انتخاب کنید.";
        public const string UserPassIncorrect = "نام کاربری/رمز عبور اشتباه می باشد";
        public const string UserBlocked = "نام کاربری شما مسدود گردیده";
        public const string UnsuccessfulSendSMS = "مشکلی در ارسال پیامک پیش آمده";
        public const string UserLoggedIn = "کاربر شما با موفقیت وارد سیستم گردید";
        public const string UserNotFound = "کابر مورد نظر یافت نشد";
        public const string InvalidSendSms = "تعداد ارسال پیامک شما بیش از حد مجاز می باشد";
        public const string SubmitError = "مشکل در ثبت اطلاعات";
        public const string SubmitErrorDelete = "مشکل در حذف اطلاعات";
        public const string HavePending ="فاکتور در حال برسی در سیستم وجود دارد";
        public const string SubmitErrorFile = "مشکل در آپلود فایل";
        public const string Error = "خطا در در یافت اطلاعات";
        public const string SendSMSError = "خطا در ارسال پیامک";
        public const string loginIsRequired = "لطفا وارد حساب کاربری خود شوید";
        public const string SubmitSuccess = "اطلاعات با موفقیت ثبت شد";
        public const string UserCardIsExist = "این شماره کارت قبلا ثبت شده است";
        public const string SubmitSuccessDelete = "اطلاعات با موفقیت حذف شد";
        public const string AccessDenied = "شما دسترسی به این بخش ندارید";
        public const string UnsuccessChangePass = "خطا در تغییر رمزعبور شما";
        public const string NotFound = "اطلاعات مورد نظر یافت نشد";
        public const string InvalidInput = "مقدار معتبر وارد کنید";
        public const string InvalidFileSize = "حجم فایل بیشتر از حد مجاز برای بارگذاری است";
        public const string InvalidFile = "این فایل مجاز به بارگذاری نیست";
        public const string DuplicateUserName = "نام کاربری تکراری است";
        public const string InvalidData = "اطلاعات ارسالی معتبر نیست";
        public const string InvalidCode = "کد معتبر نیست";
        public const string InvalidPostalCode = "کد پستی معتبر وارد نمایید";
        public const string UserIsActive = "کاربر شما فعال است";
        public const string UserIsNotActive = "کاربر شما فعال نیست";
        public const string UnsuccessfulSeendSMS = "مشکلی در ارسال پیامک پیش آمده";
        public const string InvalidNationalCode = "کد ملی معتبر وارد نمایید";
        public const string InvalidPhoneNumber = "شماره موبایل معتبر وارد نمایید";
        public const string InvalidPassword = "رمز عبور معتبر وارد نمایید";
        public const string InvalidTelNumber = "تلفن را به بدون پیش شماره و به صورت معتبر وارد نمایید.";
        public const string SuccessSendSmsCode = "کد تائید برای شماره موبایل شما ارسال گردید";
        public const string SuccessSendSmsPass = "رمزعبور برای شماره موبایل شما ارسال گردید";
        public const string SuccessChangePass = "رمزعبور شما با موفقیت تغییر یافت";
        public const string RegisterationNotVerified = "ثبت نام شما تأیید نشده است";
        public const string VerificationCodeIsIncorrect = "کد تایید صحیح نمی باشد";
        public const string ConfirmationUser = "کاربر شما فعال شد";
        public const string ConfirmationPassword = "رمز عبور و تکرار آن با هم یکسان نیست";
        public const string UserNameIsExist = "نام کاربری تکراری می باشد";
        public const string OverlapRenge = "بازه تعریف شده همپوشانی دارد!";
        public const string InvalidPriceReng = "بازه تعریف شده معتبر نیست !";
        public const string ShoppingBag = "سبد خرید شما در حالت رزو می باشد تا برگشت پاسخ از بانک امکان تغییر سبد خرید وجود ندارد";
        public const string SpecialValidDate = "تاریخ فروش ویژه را با دقت وارد کنید";

        public const string InvalidStartDate = "تاریخ و زمان شروع  معتبر نیست";
        public const string InvalidEndDate = "تاریخ و زمان  پایان معتبر نیست";
        public const string InvalidDateTime = "تاریخ و زمان شروع و پایان معتبر نیست";
        public const string InvalidEconomicCode = "کد اقتصادی معتبر نیست";
        public const string DuplicateNationalCode = "کد ملی تکراری است";
        public const string DuplicatePhoneNumber = "شماره موبایل تکراراست";
        public const string DuplicateEmail = "ایمیل تکراری است";
        public const string InvalidEmail = "ایمیل معتبر نیست";
        public const string VoucherStartedDelete = "جشنواره شروع شده است و امکان حذف وجود ندارد";

        public const string TransactionSuccess = "تراکنش با موفقیت انجام شد";
        public const string TransactionError = "تراکنش موفقیت آمیز نبود";
        public const string TransactionBankReject = "تراکنش توسط بانک معتبر نیست";
        public const string TransactionReject = "تراکنش به دلیلی مشکلاتی برگشت زده شد";
        public const string TransactionDuplicate = "تراکنش تکراری می باشد";

        public const string DuplicateUserFile = "برای این کاربر فایلی با این نوع وجود دارد امکان افزودن فایل وجود ندارد";
        public const string UploadFile = "فایل را بارگذاری کنید";
        public const string UploadFileError = "خطا در آپلود فایل";
        public const string UploadFileSuccess = "آپلود فایل با موفقیت انجام شد";
        public const string UserDocsNotApproved = "مدارک کاربر تایید نشده است";
        public const string ProductPackageDate = "تاریخ شروع سبد گذشته است امکان حذف وجود ندارد";
        public const string UserMobileNumberIsInvalid = "شماره موبایل کابر معتبر نیست";
        public const string Weight = "وزن کالا ها ثبت نشده است";
        public const string UserAddressIsActive = "این مورد آدرس فعال شما می باشد امکان حذف وجود ندارد";

        public const string CancelIsReserved = "لطفا انصراف را در صفحه درگاه پرداخت بزنید.";

    }
}
