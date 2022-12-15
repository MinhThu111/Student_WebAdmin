using Student_WebAdmin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Student_WebAdmin.Lib.SecurityManager;
using Student_WebAdmin.Lib;
using static System.String;
using Student_WebAdmin.ExtensionMethods;

namespace Student_WebAdmin.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        private async Task<ResponseData<M_AccountSignIn>> LoginFunc(EM_AccountSignIn model)
        {
            var res = new ResponseData<M_AccountSignIn>();
            if (model.userName == "admin" && model.password == "admin")
            {
                res.result = 1;
                res.data = new M_AccountSignIn
                {
                    id = 1,
                    personId = 1,
                    accessToken = "123",
                    accountType = "",
                    userName = model.userName,
                    personObj = new VM_Person
                    {
                        firstName = "Admin",
                        lastName = "01",
                        avatar = "/img/avatar.jpg",
                        email="123@gmail.com"
                    }
                };
            }
            else
            {
                res.result = 0;
                res.error.message = "Tài khoản mật khẩu không đúng!";
            }
            if (res.result != 1 || res.data == null) return res;

            //SignIn success
            M_AccountSecurity accountSec = new M_AccountSecurity()
            {
                accountId = res.data.id.ToString(),
                userId = res.data.personId?.ToString(),
                name = res.data.personObj?.lastName + " " + res.data.personObj?.firstName,
                userName = model.userName,
                avatar = IsNullOrEmpty(res.data.personObj?.avatar) ? "https://www.shutterstock.com/image-vector/avatar-vector-male-profile-gray-260nw-538707355.jpg" : res.data.personObj?.avatar,
                accessToken = res.data.accessToken,
                stayLoggedIn = model.stayLoggedIn,
                email=res.data.personObj.email
            };
            SecurityManager.SignIn(this.HttpContext, accountSec, CookieAuthenticationDefaults.AuthenticationScheme);
            return res;
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> LogIn(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return IsNullOrEmpty(returnUrl) ? Redirect("/") : Redirect(returnUrl);
            return View();
        }
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(EM_AccountSignIn model, string returnUrl)
        {
            M_JResult jResult = new M_JResult();
            if (!ModelState.IsValid)
            {
                jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(this));
                return Json(jResult);
            }
            
            var res = await LoginFunc(model);
            return Json(jResult.MapData(res, returnUrl));
        }

        public IActionResult LogOut(string returnUrl, int? autoLogout)
        {
            if (User.Identity.IsAuthenticated)
                SecurityManager.SignOut(this.HttpContext, CookieAuthenticationDefaults.AuthenticationScheme);
            //Auto logout when other user signin
            if (autoLogout != null)
            {
                switch (autoLogout)
                {
                    case 1: TempData["AutoLogoutMessage"] = "Tài khoản của bạn vừa được đăng xuất một nơi khác!"; break;
                    case 2: TempData["AutoLogoutMessage"] = "Tài khoản của bạn vừa được truy cập ở một nơi khác!"; break;
                    default: break;
                }
            }
            if (!IsNullOrEmpty(returnUrl))
                return Redirect($"/account/login?returnUrl={returnUrl}");
            return Redirect("/account/login");
        }
        public async Task<IActionResult>Register()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult>UserProfile(int? id)
        {
            return View();
        }
        //[HttpPost,ValidateAntiForgeryToken]
        //public async Task<IActionResult> UpdataProfile(M_Person model)
        //{
        //    return View();
        //}
    }
}
