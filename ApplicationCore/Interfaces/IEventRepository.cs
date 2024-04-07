using System;
using ApplicationCore.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IEventRepository
    {
        //Owners' all Orgs
        IEnumerable<Organization> GetOrgsByOwnerId(int OwnerId);

        //All Events in Each Org
        IEnumerable<Event> GetEventsByOrgId(int OrgId);

    }
}
