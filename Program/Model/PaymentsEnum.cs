using System.ComponentModel;

namespace Program.Model
{
    public enum PaymentsEnum
    {
        [Description("Kartou")]
        CARD,
        [Description("Hotove")]
        CASH
    }
}
