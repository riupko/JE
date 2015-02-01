using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JustEatDemo.Helpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Html helper for rendering image
        /// </summary>
        /// <param name="helper">Html Helper</param>
        /// <param name="url">Specifies image url</param>
        /// <param name="altText">Specifies alternative text</param>
        /// <param name="htmlAttributes">Specifies html attributes</param>
        /// <returns></returns>
        public static MvcHtmlString Image(this HtmlHelper helper,
                                    string url,
                                    string altText,
                                    object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", url);
            builder.Attributes.Add("alt", altText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// Html Helper for rendering link
        /// </summary>
        /// <param name="helper">Html Helper</param>
        /// <param name="text">Specifies link text</param>
        /// <param name="url">Specifies link url</param>
        /// <param name="target">Specifies where to open the linked document</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString Link(this HtmlHelper helper,
                                    string text,
                                    string url,
                                    string target,
                                    object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("a");
            builder.SetInnerText(text);
            builder.Attributes.Add("href", url);
            builder.Attributes.Add("target", target);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}