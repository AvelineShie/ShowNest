using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    internal interface IEventService
    {
        IEnumerable<Activity> GetEventsByOrganizationId(int organizationId);
    }
}
