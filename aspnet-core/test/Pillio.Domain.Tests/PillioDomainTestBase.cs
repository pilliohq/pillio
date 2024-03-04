using Volo.Abp.Modularity;

namespace Pillio;

/* Inherit from this class for your domain layer tests. */
public abstract class PillioDomainTestBase<TStartupModule> : PillioTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
