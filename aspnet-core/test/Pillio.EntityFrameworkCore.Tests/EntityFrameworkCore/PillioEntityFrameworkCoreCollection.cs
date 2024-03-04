using Xunit;

namespace Pillio.EntityFrameworkCore;

[CollectionDefinition(PillioTestConsts.CollectionDefinitionName)]
public class PillioEntityFrameworkCoreCollection : ICollectionFixture<PillioEntityFrameworkCoreFixture>
{

}
