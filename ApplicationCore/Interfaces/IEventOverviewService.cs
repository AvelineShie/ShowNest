﻿using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IEventOverviewService
    {
        Task<EventsOverviewDto> GetEventOverviewDto(int eventId);
    }
}
