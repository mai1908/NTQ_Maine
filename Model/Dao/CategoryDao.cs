using Model.EF; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        MaineDbContext db = null;
        public CategoryDao() 
        {
            db = new MaineDbContext();
        }

        public List<Category> ListAll() 
        {
            
            return db.Category.Where(x => x.Status == true).ToList();
        }
    }
}

