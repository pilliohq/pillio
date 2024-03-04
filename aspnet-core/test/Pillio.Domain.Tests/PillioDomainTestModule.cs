using Volo.Abp.Modularity;

namespace Pillio;

[DependsOn(
    typeof(PillioDomainModule),
    typeof(PillioTestBaseModule)
)]
public class PillioDomainTestModule : AbpModule
{

}
