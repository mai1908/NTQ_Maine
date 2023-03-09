using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        MaineDbContext db = null;
        public ProductDao() 
        {
            db = new MaineDbContext();
        }

        

        public List<Product> ListNewProduct(int top) 
        {
            return db.Product.OrderByDescending(x => x.CreatedDate).Take(top).ToList();

        }

        /// <summary>
        /// Get list product by category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>

        public List<Product> ListByCategoryId(long categoryId) 
        {
            return db.Product.Where(x => x.CategoryID == categoryId).ToList();
        }

        /// <summary>
        /// List feature product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Product.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Product.Find(productId);
            return db.Product.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }


        public Product ViewDetail(long id)
        {
            return db.Product.Find(id);
        }
    }
}
