using System;
using System.Collections.Generic;
using System.Text;
using Pillio.Localization;
using Volo.Abp.Application.Services;

namespace Pillio;

/* Inherit your application services from this class.
 */
public abstract class PillioAppService : ApplicationService
{
    protected PillioAppService()
    {
        LocalizationResource = typeof(PillioResource);
    }
}
