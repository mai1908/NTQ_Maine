using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagedList.Mvc;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        MaineDbContext db = null;
        public UserDao()
        {
            db = new MaineDbContext();
        }

        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity) 
        {
            try 
            {

            }catch (Exception ex) 
            {
                //logging
                return false;
            }
            var user = db.User.Find(entity.ID);
            user.Name = entity.Name;
            if (string.IsNullOrEmpty(entity.Password)) 
            {
                user.Password = entity.Password;
            }
            user.Address = entity.Address;
            user.Email = entity.Email;
            user.ModifiedBy = entity.ModifiedBy;
            user.ModifiedDate = DateTime.Now;
            db.SaveChanges();
            return true;
        }


        public IEnumerable<User> ListAllPaging(string searchString,int page, int pageSize) 
        {
            IOrderedQueryable<User> model = db.User;
            if (!string.IsNullOrEmpty(searchString)) 
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString)).OrderByDescending(x=>x.CreatedDate);
            }

            return db.User.OrderByDescending(x=>x.CreatedDate).ToPagedList(page, pageSize);
        }

        public User GetByUserName(string userName) 
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id) 
        {
            return db.User.Find(id); 
        }

        public object Login(string userName, string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false) 
                {
                    return -1;
                }
                else 
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public bool Delete(int id) 
        {
            try 
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception) 
            {
                return false;
            }
            
        }
        
        }
    }


        
