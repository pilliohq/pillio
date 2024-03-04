using System.Threading.Tasks;

namespace Pillio.Data;

public interface IPillioDbSchemaMigrator
{
    Task MigrateAsync();
}
