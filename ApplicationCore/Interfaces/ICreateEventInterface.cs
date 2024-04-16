using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICreateEventInterface: IRepository<Event>
    {
        IEnumerable<Organization> GetOrgById(int userId);
        IEnumerable<Event> GetOrgEventsByOrgId(int orgId);
        public Event CreateEvent(CreateEventDto require);
    }
}
