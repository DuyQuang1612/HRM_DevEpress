using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace HRM_DevEpress.Common
{
    public static class WebPageExtensions
    {
        public static class Cookies
        {
            internal static string CookiePrefix = "fastlink.web";

            public const string CultureKey = "culture";
            public const string LanguageKey = "language";
            public const string SideBarIsExpand = "sidebar.is_expand";
            public const string OriginUrl = "originUrl";

            public static string GetFullCookieName(string aName)
            {
                return CookiePrefix + "." + aName;
            }
        }

        //Pattern
        public const string EmailPattern = @"^[a-zA-Z|0-9|]+([_][a-zA-Z|0-9]+)*([.a-zA-Z|0-9]+([_][a-zA-Z|0-9]+)*)?@[a-zA-Z0-9][-a-zA-Z|0-9|]+\.([a-zA-Z][a-zA-Z|0-9]+(\.[a-zA-Z][a-zA-Z|0-9]+)?)$";
        public const string NamePattern = @"([\w\s]+)";
        public const string PhonePattern = @"^([0-9]+)$";


        public static string HomeErrorMsg = "ErrorMsg";

        public static string HomeErrorMsgInputId = "HomeErrorMsgInputId";

        public static string HomeSuccessMsg = "SuccessMsg";

        public static string HomeSuccessMsgInputId = "HomeSuccessMsgInputId";

        public static string SharedLibContentUrl = "/_content/fastlink.web.lib";

        public static string SharedLibThemeUrl = "/_content/fastlink.web.lib/themes";

        public static string ContentUrl = "";

        public static string ThemeUrl = "/themes";

        public static string CdnUrl = "https://cdn-web.fastlink.vn/v1";

        public static string GetControllerName(this Controller controller)
        {
            return controller.GetType().Name.GetControllerName();
        }

        public static string GetControllerName(this string controllerName)
        {
            if (controllerName.EndsWith("Controller"))
            {
                controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);
            }
            return controllerName;
        }

        public static string GetControllerName(this Type controllerType)
        {
            return controllerType.Name.GetControllerName();
        }

        public static string FromCdn(string url)
        {
            return CdnUrl + url;
        }

        public static string FromCdn(this RazorPageBase page, string url)
        {
            return FromCdn(url);
        }

        public static string FromTheme(string url)
        {
            return ThemeUrl + url;
        }

        public static string FromContent(string url)
        {
            return ContentUrl + url;
        }

        public static string FromTheme(this RazorPageBase page, string url)
        {
            return FromTheme(url);
        }

        public static string FromContent(this RazorPageBase page, string url)
        {
            return FromContent(url);
        }

        public static string FromThemeSharedLib(string url)
        {
            return SharedLibThemeUrl + url;
        }

        public static string FromContentSharedLib(string url)
        {
            return SharedLibContentUrl + url;
        }

        public static string FromThemeSharedLib(this RazorPageBase page, string url)
        {
            return FromThemeSharedLib(url);
        }

        public static string FromContentSharedLib(this RazorPageBase page, string url)
        {
            return FromContentSharedLib(url);
        }

        public static Dictionary<string, object> GetHtmlAttributes<TModel>(this RazorPage<TModel> page)
        {
            var dic = page.ViewData["htmlAttributes"] as Dictionary<string, object>;
            if (dic == null)
            {
                dic = new Dictionary<string, object>();
            }

            return dic;
        }


        public static string GetCookie(this Controller controller, string key)
        {
            var newKey = Cookies.GetFullCookieName(key);
            var value = controller.Request.Cookies[newKey];
            return value;
        }

        public static void SetCookie(this Controller controller, string key, string value, int expireTime = 0)
        {
            if (value == null)
            {
                return;
            }
            var newKey = Cookies.GetFullCookieName(key);

            CookieOptions option = new CookieOptions();
            if (expireTime > 0)
            {
                option.Expires = DateTime.Now.AddMinutes(expireTime);
            }
            controller.Response.Cookies.Append(newKey, value, option);
        }


        public static void SetBackgroundHeader(this RazorPageBase page, string backgroundUrl)
        {
            page.ViewBag.BackgroundUrl = backgroundUrl;
        }

    }
}
