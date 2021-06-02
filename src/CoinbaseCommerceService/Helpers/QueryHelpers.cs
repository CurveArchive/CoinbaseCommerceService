using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

namespace CoinbaseCommerceService.Helpers
{
    public static class QueryHelpers
    {
        /// <summary>
        /// Append the given query keys and values to the uri.
        /// </summary>
        /// <param name="uri">The base uri.</param>
        /// <param name="queryString">A collection of name value query pairs to append.</param>
        /// <returns>The combined result.</returns>
        public static string AddQueryString(string uri, IDictionary<string, object> queryString)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));

            if (queryString == null)
                throw new ArgumentNullException(nameof(queryString));

            return AddQueryString(uri, (IEnumerable<KeyValuePair<string, object>>) queryString);
        }

        private static string AddQueryString(string uri, IEnumerable<KeyValuePair<string, object>> queryString)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));

            if (queryString == null)
                throw new ArgumentNullException(nameof(queryString));

            var anchorIndex = uri.IndexOf('#');
            var uriToBeAppended = uri;
            var anchorText = string.Empty;

            // If there is an anchor, then the query string must be inserted before its first occurence.
            if (anchorIndex != -1)
            {
                anchorText = uri[anchorIndex..];
                uriToBeAppended = uri[..anchorIndex];
            }

            var queryIndex = uriToBeAppended.IndexOf('?');
            var hasQuery = queryIndex != -1;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(uriToBeAppended);
            
            foreach (var (key, value) in queryString)
            {
                var val = value?.ToString();
                if (val == null) continue;
                
                stringBuilder.Append(hasQuery ? '&' : '?');
                stringBuilder.Append(UrlEncoder.Default.Encode(key));
                stringBuilder.Append('=');
                stringBuilder.Append(UrlEncoder.Default.Encode(val));
                hasQuery = true;
            }

            stringBuilder.Append(anchorText);
            return stringBuilder.ToString();
        }
    }
}