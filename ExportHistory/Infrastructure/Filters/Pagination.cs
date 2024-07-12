using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportHistoryLib.Infrastructure.Filters
{
    public class Pagination
    {
        private readonly int _take;
        private readonly int _skip;

        public int Take { get => _take; }
        public int Skip { get => _skip; }

        private Pagination(int take, int skip)
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

            public Pagination Build()
            {
                return new Pagination(_take, _skip);
            }
        }
    }
}
