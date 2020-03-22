﻿using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task Add(User user);
        User Get_Now();
        Task Set_Now(User user);
    }
}
