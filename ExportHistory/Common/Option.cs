
namespace ExportHistoryLib.Common
{
    public class Option
    {
        public class Some<T> : IOption<T>
        {
            private readonly T value;

            public Some(T value)
            {
                this.value = value ?? throw new ArgumentNullException(nameof(value));
            }

            public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
            {
                if (some == null) throw new ArgumentNullException(nameof(some));
                if (none == null) throw new ArgumentNullException(nameof(none));

                return some(value);
            }
        }

        public class None<T> : IOption<T>
        {
            public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
            {
                if (some == null) throw new ArgumentNullException(nameof(some));
                if (none == null) throw new ArgumentNullException(nameof(none));

                return none();
            }
        }
    }
}
