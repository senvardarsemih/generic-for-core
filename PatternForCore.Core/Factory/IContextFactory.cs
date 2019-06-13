using PatternForCore.Core.EFContext;

namespace PatternForCore.Core.Factory
{
    public interface IContextFactory
    {
        IDatabaseContext DbContext { get; }
    }
}