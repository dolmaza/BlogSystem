﻿using Core.Entities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface IUserService : IBaseService
    {
        List<User> GetAllGridItems();
        User GetByID(int? ID);
        User GetByEmailAndPassword(string email, string passwordMd5);

        bool IsUserEmailNotUnique(string email, int? ID = null);

        int? Add(User user);
        List<int?> AddRange(List<User> users);

        void Update(User user);

        void Remove(User user);
        void RemoveRange(List<User> users);
    }
}
