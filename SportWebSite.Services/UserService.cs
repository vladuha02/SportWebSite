using AutoMapper;
using SportWebSite.Data.Repository;
using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;
using System;
using System.Collections.Generic;

namespace SportWebSite.Services
{
    public class UserService : IUserService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UserServiceModel AddNewUser(UserServiceModel userServiceModel)
        {
            var user = _mapper.Map<User>(userServiceModel);

            _unitOfWork.Users.Add(user);
            _unitOfWork.Commit();

            _unitOfWork.Dispose();

            return userServiceModel;
        }

        public IEnumerable<User> GetAvailableUsers()
        {
            return _unitOfWork.Users.GetAll();
        }

        public User GetUserById(string id)
        {
            return _unitOfWork.Users.Get(id);
        }

        public User UpdateUser(UserServiceModel userServiceModel)
        {
            var existingUser = _unitOfWork.Users.Get(userServiceModel.Id);

            existingUser.Gender = userServiceModel.Gender;
            existingUser.BirthDate = userServiceModel.BirthDate;
            existingUser.Email = userServiceModel.Email;
            existingUser.Location = userServiceModel.Location;
            existingUser.Name = userServiceModel.Name;
            existingUser.Role = userServiceModel.Role;
            existingUser.UserName = userServiceModel.UserName;

            _unitOfWork.Users.Update(existingUser);

            _unitOfWork.Commit();

            _unitOfWork.Dispose();

            return existingUser;
        }

        public bool RemoveUser(string id)
        {
            bool flag = _unitOfWork.Users.Delete(id);
            if (flag)
            {
                _unitOfWork.Commit();
            }
            _unitOfWork.Dispose();

            return flag;
        }
    }
}