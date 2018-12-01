
namespace XmlParser.Interfaces
{
    public interface IParser<in TSource, out TResult>
    {

        TResult Parse(TSource source);
    }
}
