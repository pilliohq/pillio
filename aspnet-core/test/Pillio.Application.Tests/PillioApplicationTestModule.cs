using Volo.Abp.Modularity;

namespace Pillio;

[DependsOn(
    typeof(PillioApplicationModule),
    typeof(PillioDomainTestModule)
)]
public class PillioApplicationTestModule : AbpModule
{

}
