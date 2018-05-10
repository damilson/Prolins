using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Util.Helpers
{
    public static class EnumDisplayHelpers
    {
        public static MvcHtmlString EnumDisplayHelper<TEnum>(this HtmlHelper htmlHelper, TEnum value)
        {
            if (value == null)
                return new MvcHtmlString(string.Empty);

            var fieldType = Nullable.GetUnderlyingType(value.GetType()) != null ?
                Nullable.GetUnderlyingType(value.GetType()) :
                value.GetType();

            var fieldInfo = fieldType.GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null)
                return new MvcHtmlString(string.Empty);

            return new MvcHtmlString((descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString());
        }
    }
}
    