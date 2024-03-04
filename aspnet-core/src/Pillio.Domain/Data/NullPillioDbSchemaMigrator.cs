using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Pillio.Data;

/* This is used if database provider does't define
 * IPillioDbSchemaMigrator implementation.
 */
public class NullPillioDbSchemaMigrator : IPillioDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
