﻿using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EFAuthorDal:GenericRepository<Author>,IAuthorDal
    {
       

    }
}
