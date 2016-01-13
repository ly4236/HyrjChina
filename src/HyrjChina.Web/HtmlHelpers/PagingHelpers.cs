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
            TagBuilder ui = new TagBuilder("ul");
            ui.AddCssClass("pagination");

            TagBuilder liLast = new TagBuilder("li");
            if (pagingInfo.CurrentPage == 1)
            {
                liLast.AddCssClass("pagination");
            }

            TagBuilder iLast = new TagBuilder("i");
            iLast.AddCssClass("icon-double-angle-left");

            TagBuilder aLast = new TagBuilder("a");
            if (pagingInfo.CurrentPage > 1)
            {
                aLast.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
            }
            aLast.InnerHtml = iLast.ToString();
            liLast.InnerHtml = aLast.ToString();
            ui.InnerHtml = liLast.ToString();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder li = new TagBuilder("li");
                //if (pagingInfo.CurrentPage == i)
                //{
                //    li.AddCssClass("prev disabled");
                //}
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", pageUrl(i));

                a.InnerHtml = i.ToString();
                li.InnerHtml = a.ToString();
                ui.InnerHtml += li.ToString();
            }

            TagBuilder liNext = new TagBuilder("li");
            if (pagingInfo.CurrentPage == pagingInfo.TotalPages)
            {
                liNext.AddCssClass("pagination");
            }

            TagBuilder iNext = new TagBuilder("i");
            iNext.AddCssClass("icon-double-angle-right");

            TagBuilder aNext = new TagBuilder("a");
            if (pagingInfo.CurrentPage< pagingInfo.TotalPages)
            {
                aNext.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
            }


            aNext.InnerHtml = iNext.ToString();
            liNext.InnerHtml = aNext.ToString();
            ui.InnerHtml += liNext.ToString();
            return MvcHtmlString.Create(ui.ToString());
        }

    }
}