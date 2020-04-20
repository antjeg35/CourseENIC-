using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP2Module5LesPizzas.Helpers
{
    public static class CustomSubmitExtensions
    {
        public static MvcHtmlString CustomSubmit(this HtmlHelper helper, string type, string action)
        {
            return new MvcHtmlString(String.Format("<input type='{0}' value='{1}' class='btn btn - default' />", type, action));
        }
    }
}