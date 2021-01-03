﻿using Backend_Rest__API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend_Rest__API.Repository
{
    public class ProductRepository: Repository<Tbl_Product>
    {
        public List<Tbl_Product> GetProductsByCategory(int id)
        {
            return this.GetAll().Where(X => X.CategoryId == id).ToList();
        }
    }
}