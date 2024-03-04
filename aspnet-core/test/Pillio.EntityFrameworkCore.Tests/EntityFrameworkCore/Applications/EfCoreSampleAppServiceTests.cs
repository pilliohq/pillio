using Pillio.Samples;
using Xunit;

namespace Pillio.EntityFrameworkCore.Applications;

[Collection(PillioTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<PillioEntityFrameworkCoreTestModule>
{

}
