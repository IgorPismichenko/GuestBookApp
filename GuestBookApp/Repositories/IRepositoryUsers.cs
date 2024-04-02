﻿using GuestBookApp.Models;

namespace GuestBookApp.Repositories
{
    public interface IRepositoryUsers
    {
        Task<List<Users>> GetUsersList();
        IQueryable<Users> CheckUser(LoginModel logon);
        IQueryable<Users> CheckRegisterUser(RegisterModel reg);
        Task Create(Users item);
        Task Save();
    }
}
