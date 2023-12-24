﻿using StoreManager.DB_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Models.Abstract.Interfaces
{
    public enum Role { client, guest, admin, manager };
    internal interface IStore
    {
        User user { get; set; }
    }
}
