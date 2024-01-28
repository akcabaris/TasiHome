using Microsoft.EntityFrameworkCore;
using ServiceETW.Models;
using ServiceETW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceETW.Classes
{
    public class UserService
    {
        EsyaTasimaContext _context;

        public UserService()
        {
            _context = new EsyaTasimaContext();
        }


        public List<UserVM> GetUsers()
        {
            List<UserVM> result = new List<UserVM>();
            var list = _context.Users.ToList();
            foreach (var user in list)
            {
                UserVM vm = new UserVM();
                vm.Id = user.Id;
                vm.Password = user.Password;
                vm.Email = user.Email;
                vm.FullName = user.FullName;
                vm.PhoneNumber = user.PhoneNumber;
                result.Add(vm);
            }

            return result;
        }

        public List<UserVM> GetUsersWhoLogin(int userId)
        {
            List<UserVM> result = new List<UserVM>();
            var list = _context.Users.ToList();
            foreach (var user in list)
            {
                if (user.Id == userId)
                {
                    UserVM vm = new UserVM();
                    vm.Id = user.Id;
                    vm.Password = user.Password;
                    vm.Email = user.Email;
                    vm.FullName = user.FullName;
                    vm.PhoneNumber = user.PhoneNumber;
                    result.Add(vm);
                }
            }

            return result;
        }

        public void AddUser(UserVM vm)
        {
            User model = new User();
            model.Id = vm.Id;
            model.Password = vm.Password;
            model.Email = vm.Email;
            model.FullName = vm.FullName;
            model.PhoneNumber = vm.PhoneNumber;
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public UserVM GetEditUser(int id)
        {
            var model = _context.Users.Find(id);
            var result = new UserVM();

            result.Id = model.Id;
            result.FullName = model.FullName;
            result.Email = model.Email;
            result.Password = model.Password;
            result.PhoneNumber = model.PhoneNumber;
            return result;


        }

        public void EditUser(UserVM vm)
        {
            var model = _context.Users.Find(vm.Id);
            model.FullName = vm.FullName;
            model.PhoneNumber = vm.PhoneNumber;
            model.Email = vm.Email;
            model.Password = vm.Password;

            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }
    } 
}
