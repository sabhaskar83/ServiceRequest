using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequest.Enum
{
    public class Enums
    {
        public enum CurrentStatus
        {
            NotApplicable=0,
            Created=1,
            InProgress=2,
            Complete=3,
            Canceled=4
        }

    }
}
