using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DataAccess
{
    public enum EmployeeManagerStatus
    {
        success = 1,
        failed = -1,
        invalidName = -2,
        invalidID = -3,
        duplicate = -4,
    }
}
