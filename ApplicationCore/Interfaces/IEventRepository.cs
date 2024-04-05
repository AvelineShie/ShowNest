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
        public IEnumerable<Organization> GetOrgIdByOwnerId(int OwnerId);

        //All Events in Each Org
        public IEnumerable<Event> GetEventIdByOrgId(int OrgId);

    }
}
