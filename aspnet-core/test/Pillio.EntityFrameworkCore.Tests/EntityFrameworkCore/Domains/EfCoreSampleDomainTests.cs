using Pillio.Samples;
using Xunit;

namespace Pillio.EntityFrameworkCore.Domains;

[Collection(PillioTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<PillioEntityFrameworkCoreTestModule>
{

}
