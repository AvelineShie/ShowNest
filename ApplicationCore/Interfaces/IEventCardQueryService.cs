using ApplicationCore.Entities;
using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IEventCardQueryService
    {
        Task<List<CategoryTag>> GetAllCardsByCategoryId(int categoryId);

        //Task<List<CategoryTag>> GetNumbersOfCardsByCategoryId(int cardAmount, int categoryId);
        Task<List<Event>> GetNumbersOfCardsByCategoryId(int cardAmount, int categoryId);
        Task<List<EventIndexDto>> GetEventIndexCards();
    }
}
