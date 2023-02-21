using System.Text;

namespace WebApplication1.Application.Helpers;

public static class CacheKeyHelper
{
    public static string GetUniqueKeyAsString(string path, object obj)
    {
        var hash = GetHashByProperty(obj);
        return $"{path}/{hash}";
    }

    private static string GetHashByProperty(object obj)
    {
        var sb = new StringBuilder();
        var propertyInfos = obj.GetType().GetProperties();
        foreach (var prop in propertyInfos)
        {
            sb.Append(prop.GetValue(obj));
        }

        return sb.ToString();
    }
}