using System.Text;

namespace WebApplication1.Helper;

public class CacheKeyHelper
{
    private readonly string _path;
    private readonly object _obj;
    
    public CacheKeyHelper(string path, object obj)
    {
        _path = path;
        _obj = obj;
    }

    public string GetUniqueKeyAsString()
    {
        var sb = new StringBuilder(_path);
        sb.Append(_obj);
        return sb.ToString();
    }
}