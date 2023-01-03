using System;
using System.ComponentModel;
using System.Reflection;

namespace Program.Model
{
    public enum TablesEnum
    {
        [Description("ADRESY")]
        ADRESS,
        [Description("KARTY")]
        CARD,
        [Description("HOTOVE")]
        CASH,
        [Description("ZBOZI")]
        GOODS,
        [Description("POJISTOVNY")]
        INSURANCE,
        [Description("KLIENTI")]
        KLIENT,
        [Description("PLATBY")]
        PAYMENT,
        [Description("SKLADY")]
        STORAGE,
        [Description("USERS")]
        USER,
        [Description("ZAMESTNANCI")]
        WORKER,
        [Description("PRACOVNI_POZICE")]
        WORK_POSITION
    }
}
