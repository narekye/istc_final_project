using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.BLL.Models;
using ISTC.CRM.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ISTC.CRM.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(CRMContext context) : base(context)
        {

        }

        public void AddUser(UserBL user)
        {
            var dalUser = new User
            {
                Name = user.Name,
                Surname = user.Surname,
                CompanyName = user.CompanyName,
                Country = user.Country,
                Email = user.Email,
                Position = user.Position
            };

            var exists = UnitOfWork.UserRepository.GetById(user.Id);

            if (exists != null)
            {
                throw CreateException("User with the same email already exists");
            }

            UnitOfWork.UserRepository.Add(dalUser);

            UnitOfWork.SaveChanges();
        }

        public void DeleteUserById(int userId)
        {
            if (userId <= 0)
            {
                throw CreateException("User not found!!");
            }

            var dalUser = UnitOfWork.UserRepository.GetById(userId);

            if (dalUser == null)
            {
                throw CreateException("User not found!!");
            }

            UnitOfWork.UserRepository.Delete(dalUser);

            UnitOfWork.SaveChanges();
        }

        public void EditUser(UserBL user)
        {
            if (user.Id <= 0)
            {
                throw CreateException("User not found!!");
            }

            var dalUser = UnitOfWork.UserRepository.GetById(user.Id);

            if (dalUser == null)
            {
                throw CreateException("User not found!!");
            }


            if (!string.IsNullOrWhiteSpace(user.Name))
                dalUser.Name = user.Name;

            if (!string.IsNullOrWhiteSpace(user.Email))
                dalUser.Email = user.Email;

            if (!string.IsNullOrWhiteSpace(user.Country))
                dalUser.Country = user.Country;

            if (!string.IsNullOrWhiteSpace(user.CompanyName))
                dalUser.CompanyName = user.CompanyName;

            if (!string.IsNullOrWhiteSpace(user.Surname))
                dalUser.Surname = user.Surname;

            if (!string.IsNullOrWhiteSpace(user.Position))
                dalUser.Position = user.Position;

            UnitOfWork.SaveChanges();
        }

        public UserBL GetUserById(int userId)
        {
            if (userId <= 0)
            {
                throw CreateException("User not found!!");
            }

            var dalUser = UnitOfWork.UserRepository.GetById(userId);

            if (dalUser == null)
            {
                throw CreateException("User not found!!");
            }

            return new UserBL
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Surname = dalUser.Surname,
                Country = dalUser.Country,
                CompanyName = dalUser.CompanyName,
                Position = dalUser.Position,
                Email = dalUser.Email
            };
        }

        public IEnumerable<UserBL> GetAll()
        {
            var dalUsers = UnitOfWork.UserRepository.GetAll();

            return dalUsers.Select(x =>
                new UserBL
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Country = x.Country,
                    CompanyName = x.CompanyName,
                    Position = x.Position,
                    Email = x.Email,
                });
        }
    }
}
