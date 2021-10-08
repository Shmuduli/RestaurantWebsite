using RestaurantWebsite.UI.DBContext;
using RestaurantWebsite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyContext _myContext;

        public CategoryRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IEnumerable<Category> AllCategories => _myContext.Categories;
    }
}
