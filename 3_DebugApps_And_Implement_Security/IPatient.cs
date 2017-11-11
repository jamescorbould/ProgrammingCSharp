using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DebugApps_And_Implement_Security
{
    interface IPatient
    {
        Int64 NHSNumber { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        Task<Guid> DoBulkLoad(string callbackURL);
    }
}
