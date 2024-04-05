using ApplicationCore.Entities;
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

        Task<List<CategoryTag>> GetNumbersOfCardsByCategoryId(int cardAmount, int categoryId);
    }
}
