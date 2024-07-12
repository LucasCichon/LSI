
namespace ExportHistoryLib.Common
{
    public interface IOption<T>
    {
        TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none);
    }
}
