using System.Threading.Tasks;

namespace Senele.Solution.Data;

public interface ISolutionDbSchemaMigrator
{
    Task MigrateAsync();
}
