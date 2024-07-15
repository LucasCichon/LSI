
namespace ExportHistoryLib.Infrastructure.Filters
{
    public class PaginationFilter
    {
        private readonly int _take;
        private readonly int _skip;

        public int Take { get => _take; }
        public int Skip { get => _skip; }

        private PaginationFilter(int take, int skip)
        {
            _take = take;
            _skip = skip;
        }
        public class Builder()
        {
            private int _take = 100;
            private int _skip = 0;

            public void SetTake(int take) { _take = take; }
            public void SetSkip(int skip) { _skip = skip; }

            public PaginationFilter Build()
            {
                return new PaginationFilter(_take, _skip);
            }
        }
    }
}
