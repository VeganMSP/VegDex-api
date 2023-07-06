using System.Text;
using System.Text.RegularExpressions;

namespace VegDex.Core.Utilities;

public static class UrlUtilities
{
    public static string ToUrlSlug(this string value)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        value = value.ToLowerInvariant();

        // Remove accents
        byte[] bytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(value);
        value = Encoding.ASCII.GetString(bytes);

        value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);
        value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);
        value = value.Trim('-', '_');
        value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);
        return value;
    }
}
