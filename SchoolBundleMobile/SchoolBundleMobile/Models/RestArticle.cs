using System;
using System.Collections.Generic;
using System.Text;
using SchoolBundleMobile.Helpers;

namespace SchoolBundleMobile.Models
{
    public class RestArticle
    {
        public static string GenerateURL()
        {
            return string.Format(Constants.ARTICLE_SEARCH,Constants.X_APPID, Constants.X_CUSTID, Constants.X_USERTOKEN, Constants.X_MVCHOST);
        }

    }
}
