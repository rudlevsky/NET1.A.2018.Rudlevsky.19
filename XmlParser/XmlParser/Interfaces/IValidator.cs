
namespace XmlParser.Interfaces
{
    public interface IValidator<in TSource>
    {

        bool IsValid(TSource source);
    }
}
