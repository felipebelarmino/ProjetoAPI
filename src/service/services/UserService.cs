

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.Entities;
using domain.Interfaces;
using domain.Services.User;

namespace services
{
  public class UserService : IUserService
  {
    private IRepository<UserEntity> _userRepository;

    public UserService(IRepository<UserEntity> userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<bool> Delete(Guid id)
    {
      return await _userRepository.DeleteAsync(id);
    }

    public async Task<UserEntity> Get(Guid id)
    {
      return await _userRepository.SelectAsync(id);
    }

    public async Task<IEnumerable<UserEntity>> GetAll()
    {
      return await _userRepository.SelectAsync();
    }

    public async Task<UserEntity> Post(UserEntity user)
    {
      return await _userRepository.InsertAsync(user);
    }

    public async Task<UserEntity> Put(UserEntity user)
    {
      return await _userRepository.UpdateAsync(user);
    }
  }
}
