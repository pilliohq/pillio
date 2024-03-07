using Pillio.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Pillio.Permissions;

public class PillioPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PillioPermissions.GroupName);
        
        var booksPermission = myGroup.AddPermission(PillioPermissions.CareHomes.Default, L("Permission:CareHomes"));
        booksPermission.AddChild(PillioPermissions.CareHomes.Create, L("Permission:CareHomes.Create"));
        booksPermission.AddChild(PillioPermissions.CareHomes.Edit, L("Permission:CareHomes.Edit"));
        booksPermission.AddChild(PillioPermissions.CareHomes.Delete, L("Permission:CareHomes.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PillioResource>(name);
    }
}
