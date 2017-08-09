using System;
using System.Collections.Generic;

namespace Dashboard.Presenters
{
    class PresenterBase
    {
        private readonly List<Object> _synclock = new List<object>();

        public Object Lock()
        {
            return _synclock;
        }

    }
}
