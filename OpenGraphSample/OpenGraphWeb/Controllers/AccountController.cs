using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using OpenGraphWeb.Models;

namespace OpenGraphWeb.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "指定されたユーザー名またはパスワードが正しくありません。");
                }
            }

            // ここで問題が発生した場合はフォームを再表示します
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // ユーザーの登録を試みます
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // ここで問題が発生した場合はフォームを再表示します
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // 特定のエラー シナリオでは、ChangePassword は
                // false を返す代わりに例外をスローします。
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "現在のパスワードが正しくないか、新しいパスワードが無効です。");
                }
            }

            // ここで問題が発生した場合はフォームを再表示します
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // すべてのステータス コードの一覧については、http://go.microsoft.com/fwlink/?LinkID=177550 を
            // 参照してください。
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "このユーザー名は既に存在します。別のユーザー名を入力してください。";

                case MembershipCreateStatus.DuplicateEmail:
                    return "その電子メール アドレスのユーザー名は既に存在します。別の電子メール アドレスを入力してください。";

                case MembershipCreateStatus.InvalidPassword:
                    return "指定されたパスワードは無効です。有効なパスワードの値を入力してください。";

                case MembershipCreateStatus.InvalidEmail:
                    return "指定された電子メール アドレスは無効です。値を確認してやり直してください。";

                case MembershipCreateStatus.InvalidAnswer:
                    return "パスワードの回復用に指定された回答が無効です。値を確認してやり直してください。";

                case MembershipCreateStatus.InvalidQuestion:
                    return "パスワードの回復用に指定された質問が無効です。値を確認してやり直してください。";

                case MembershipCreateStatus.InvalidUserName:
                    return "指定されたユーザー名は無効です。値を確認してやり直してください。";

                case MembershipCreateStatus.ProviderError:
                    return "認証プロバイダーからエラーが返されました。入力を確認してやり直してください。問題が解決しない場合は、システム管理者に連絡してください。";

                case MembershipCreateStatus.UserRejected:
                    return "ユーザーの作成要求が取り消されました。入力を確認してやり直してください。問題が解決しない場合は、システム管理者に連絡してください。";

                default:
                    return "不明なエラーが発生しました。入力を確認してやり直してください。問題が解決しない場合は、システム管理者に連絡してください。";
            }
        }
        #endregion
    }
}
