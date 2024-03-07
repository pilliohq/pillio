namespace Pillio.Permissions;

public static class PillioPermissions
{
    public const string GroupName = "Pillio";

    public static class CareHomes
    {
        public const string Default = GroupName + ".CareHomes";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
