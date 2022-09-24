﻿using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Account;

namespace OnlineShoppingCartSystem.Services.Account
{
    public class RegisterService 
    {
        IAccount<Users> _repository;

        public RegisterService(IAccount<Users> repo)
        {
            _repository = repo;
        }
        public async Task<Users> GetByUserId(int id)
        {
            //throw new NotImplementedException();
            return  await _repository.GetByUserId(id);
        }

        public async Task<Users> Insert(Users entity)
        {
            //throw new NotImplementedException();
            return await _repository.Insert(entity);
        }
        public async Task<Users> GetByUsername(string username)
        {
            return await _repository.GetByUsername(username);
        }
        public async Task DeleteUserAccount (Users entity)
        {
            await _repository.DeleteUserAccount(entity);
        }
        public  Task Save()
        {
            //throw new NotImplementedException();
            return  _repository.Save();
            
        }
    }
}
