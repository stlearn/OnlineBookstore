﻿using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineBookstore.Services
{
    public class UserService : IUserService
    {

        private readonly List<User> _users = new List<User>();
        private readonly OnlineBookstoreDBContext _context;

        public UserService(OnlineBookstoreDBContext context)
        {
            this._context = context;
            _users = _context.User.ToList();
        }
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetAll()
        {
            return Task.Run(function: () => _users);
        }

        public Task<bool> ExistUser(string userName)
        {
            return Task.Run(function: () =>
                {
                    return GetAll().Result.Exists(x => x.UserName == userName);
                }
            );
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> Add(User user)
        {
            return Task.Run(function: () =>
            {
                if (ExistUser(user.UserName).Result)
                {
                    return false;
                }

                _users.Add(user);
                _context.User.Add(user);
                _context.SaveChanges();
                return true;

            });
        }
        /// <summary>
        /// 根据用户名获取ID
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public Task<int> GetId(string Username)
        {
            return Task.Run(function: () =>
            {
                var user = _users.Find(x => x.UserName == Username);
                return user.UserId;
            });
        }
    }
}
