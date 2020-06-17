using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
 public  class SeoLink
    {
        public static string GenerateUrl(string Url)
        {
            string UrlPeplaceSpecialWords = Regex.Replace(Url, @"&quot;|['"",&?%\.!()@$^_+=*:#/\\-]", " ").Trim();
            string RemoveMutipleSpaces = Regex.Replace(UrlPeplaceSpecialWords, @"\s+", " ");
            string ReplaceDashes = RemoveMutipleSpaces.Replace(" ", "-");
            string DuplicateDashesRemove = ReplaceDashes.Replace("--", "-");
            return DuplicateDashesRemove.ToLower();
        }
    }
}
