﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
    public interface IGetEntries
    {
        int GetEntriesAmout(bool isAdmin);
    }
}
