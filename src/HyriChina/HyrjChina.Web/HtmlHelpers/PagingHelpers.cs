using HyrjChina.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            result.Append(GetPageLast(pagingInfo, pageUrl));
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("active");
                }
                li.InnerHtml = tag.ToString();
                result.Append(li.ToString());
            }
            result.Append(GetPageNext(pagingInfo, pageUrl));
            return MvcHtmlString.Create(result.ToString());
        }
        private static string GetPageLast(PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");
            if (pagingInfo.CurrentPage == 1)
            {
                a.MergeAttribute("href", "#");
                a.AddCssClass("disabled");
            }
            else
            {
                a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
            }
            a.InnerHtml = "<<";
            li.InnerHtml = a.ToString();
            return li.ToString();
        }
        private static string GetPageNext(PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");
            if (pagingInfo.CurrentPage == pagingInfo.TotalPages)
            {
                a.MergeAttribute("href", "#");
                a.AddCssClass("disabled");
            }
            else
            {
                a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
            }
            a.InnerHtml = ">>";
            li.InnerHtml = a.ToString();
            return li.ToString();
        }
    }
}