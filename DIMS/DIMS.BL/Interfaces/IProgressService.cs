﻿using HIMS.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
    public interface IProgressService
    {
        IEnumerable<ProgressDTO> GetUserProgress(int userId);
        ProgressDTO GetProgress(int ProgressId);
    }
}
