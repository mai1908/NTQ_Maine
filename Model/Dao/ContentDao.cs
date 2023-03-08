﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        MaineDbContext db = null;
        public ContentDao()
        {
            db = new MaineDbContext();
        }

        public Content GetByID(long id) 
        {
            return db.Content.Find(id);
        }
    }
}
