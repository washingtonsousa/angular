using System;
using System.Text;
using System.Web;
using System.Web.Http.Description;

namespace HRWeb.Areas.HelpPage
{
    public static class ApiDescriptionExtensions
    {
        /// <summary>
        /// Generates an URI-friendly ID for the <see cref="ApiDescription"/>. E.g. "Get-Values-id_name" instead of "GetValues/{id}?name={name}"
        /// </summary>
        /// <param name="description">The <see cref="ApiDescription"/>.</param>
        /// <returns>The ID as a string.</returns>
        public static string GetFriendlyId(this ApiDescription description)
        {
            string path = description.RelativePath;
            string[] urlParts = path.Split('?');
            string localPath = urlParts[0];
            string queryKeystring = null;
            if (urlParts.Length > 1)
            {
                string query = urlParts[1];
                string[] queryKeys = HttpUtility.ParseQuerystring(query).AllKeys;
                queryKeystring = string.Join("_", queryKeys);
            }

            stringBuilder friendlyPath = new stringBuilder();
            friendlyPath.AppendFormat("{0}-{1}",
                description.HttpMethod.Method,
                localPath.Replace("/", "-").Replace("{", string.Empty).Replace("}", string.Empty));
            if (queryKeystring != null)
            {
                friendlyPath.AppendFormat("_{0}", queryKeystring.Replace('.', '-'));
            }
            return friendlyPath.ToString();
        }
    }
}