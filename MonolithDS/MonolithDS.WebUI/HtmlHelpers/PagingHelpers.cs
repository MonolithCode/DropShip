using System;
using System.Text;
using System.Web.Mvc;
using MonolithDS.WebUI.Models;

namespace MonolithDS.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pageInfo, 
            Func<int,string> pageurl )
        {
            var results = new StringBuilder();
            for (var i = 0; i < pageInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href",pageurl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                results.Append(tag);
            }
            return MvcHtmlString.Create(results.ToString());
        }
    }
}
