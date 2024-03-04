namespace Pillio.Enums
{
    public enum OrderStatus
    {
        Processing = 0, // somebody look at it - 
        PriorityProcessing = 1,
        Confirmed = 2,
        Delivery = 3, //Ship today - orange
        Active = 4, // patient has it green
        Low = 5, // red
        Completed = 6, // ship, need to order new batch - purple
        None = 8,

    }
}
