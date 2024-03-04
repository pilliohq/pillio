using Volo.Abp.Settings;

namespace Pillio.Settings;

public class PillioSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PillioSettings.MySetting1));
    }
}
