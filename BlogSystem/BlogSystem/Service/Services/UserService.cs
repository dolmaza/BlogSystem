using Core.Entities;
using Core.IRepositries;
using Service.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService()
        {
            _userRepository = GetRepository<User>();
        }

        public List<User> GetAllGridItems()
        {
            var users = _userRepository.GetAll(orderBy: ob => ob.OrderByDescending(u => u.CreateTime)).ToList();

            return users;
        }

        public User GetByID(int? ID)
        {
            var user = _userRepository.GetByID(ID);

            return user;
        }

        public User GetByEmailAndPassword(string email, string passwordMd5)
        {
            var user = _userRepository.GetOne
                (
                    u => u.Email == email && u.Password == passwordMd5,
                    u => u.Role, u => u.Role.Permissions
                );

            return user;
        }

        public bool IsUserEmailNotUnique(string email, int? ID = null)
        {
            return _userRepository.Exists(u => (ID == null && u.Email == email) || (u.ID != ID && u.Email == email));
        }

        public int? Add(User user)
        {
            _userRepository.Add(user);
            _userRepository.Complate();
            IsError = _userRepository.IsError;

            return user.ID;
        }

        public List<int?> AddRange(List<User> users)
        {
            _userRepository.AddRange(users);
            _userRepository.Complate();
            IsError = _userRepository.IsError;

            return users.Select(u => u.ID).ToList();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
            _userRepository.Complate();
            IsError = _userRepository.IsError;
        }

        public void Remove(User user)
        {
            _userRepository.Remove(user);
            _userRepository.Complate();
            IsError = _userRepository.IsError;

        }

        public void RemoveRange(List<User> users)
        {
            _userRepository.RemoveRange(users);
            _userRepository.Complate();
            IsError = _userRepository.IsError;

        }
    }
}
