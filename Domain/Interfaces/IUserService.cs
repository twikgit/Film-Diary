﻿using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<Customer>> GetAll();

        Task<Customer> GetById(int id);

        Task Create(Customer model);

        Task Update(Customer model);

        Task Delete(int id);
    }
}