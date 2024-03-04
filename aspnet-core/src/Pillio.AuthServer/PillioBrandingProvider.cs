using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Pillio;

[Dependency(ReplaceServices = true)]
public class PillioBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Pillio";
}
