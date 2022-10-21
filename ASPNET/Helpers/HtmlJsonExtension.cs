using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ServiceStack;

namespace ASPNET.Helpers
{
    public static class HtmlJsonExtension
    {
        public static IHtmlString ToJson(this HtmlHelper helper, object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new JavaScriptDateTimeConverter());
            return (IHtmlString)helper.Raw(JsonConvert.SerializeObject(obj, settings));
        }
    }
}
