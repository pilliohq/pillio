using Pillio.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Pillio.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PillioController : AbpControllerBase
{
    protected PillioController()
    {
        LocalizationResource = typeof(PillioResource);
    }
}
