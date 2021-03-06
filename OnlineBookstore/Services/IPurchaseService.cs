﻿using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Services
{
    public interface IPurchaseService
    {
        Task<List<Purchase>> GetAll();
        Task<List<Purchase>> GetById(int orderId);
        Task<bool> Add(int order,Purchase purchase);
        Task<bool> FindByBookid(int oeder, int bookid);
        Task AddBook(int order,int bookid,int num);
    }
}
