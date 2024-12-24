using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<Customer> GetById(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.CustomerId == id);
            return user.First();
        }

        public async Task Create(Customer model)
        {
            await _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Customer model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.CustomerId == id);

            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}