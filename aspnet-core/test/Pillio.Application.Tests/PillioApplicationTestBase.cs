using Volo.Abp.Modularity;

namespace Pillio;

public abstract class PillioApplicationTestBase<TStartupModule> : PillioTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
