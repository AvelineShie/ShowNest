using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CategoryTagsRepository : EfRepository<CategoryTag>, ICategoryTagsRepository
    {
        public CategoryTagsRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
