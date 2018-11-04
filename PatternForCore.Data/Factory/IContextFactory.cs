using System;
using System.Collections.Generic;
using System.Text;
using PatternForCore.Data.EFContext;

namespace PatternForCore.Data.Factory
{
    public interface IContextFactory
    {
        IDatabaseContext DbContext { get; }
    }
}
