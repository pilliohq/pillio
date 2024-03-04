namespace Pillio.Enums
{

    /// <summary>
    ///🔴 : available count less than 7 doses
    ///🟠 : available count less than or equal to 14 doses
    ///🟢 : available count greater than 14 doses
    /// </summary>
    public enum MedicationAvailableStatus
    {
        Green = 0,
        Yellow = 1,
        Red = 2
    }
}