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
    public class IlanService
    {

        EsyaTasimaContext _context;

        public IlanService()
        {
            _context = new EsyaTasimaContext();
        }

        public List<IlanVM> GetIlans()
        {
            List<IlanVM> result = new List<IlanVM>();
            var list = _context.Ilans.Include(b => b.User).ToList();
            foreach (var ilan in list)
            {
                IlanVM vm = new IlanVM();
                ilan.UserId = 1;
                vm.Id = ilan.Id;
                vm.Aciklama = ilan.Aciklama;
                vm.Tarih = ilan.Tarih;
                vm.Baslik = ilan.Baslik;
                vm.Sehir = ilan.Sehir;
                vm.Ilce = ilan.Ilce;
                vm.Ilantipi = ilan.Ilantipi;
                vm.UserId = ilan.UserId;
                vm.UserFullName = ilan.User.FullName;
                vm.UserTelNo = ilan.User.PhoneNumber;
                result.Add(vm);
            }

            return result;
        }

        public List<IlanVM> GetIlansWhoLogin(int userId)
        {
            List<IlanVM> result = new List<IlanVM>();
            var list = _context.Ilans.Include(b => b.User).ToList();
            foreach (var ilan in list)
            {
                if(ilan.UserId == userId) 
                {
                IlanVM vm = new IlanVM();
                ilan.UserId = userId;
                vm.Id = ilan.Id;
                vm.Aciklama = ilan.Aciklama;
                vm.Tarih = ilan.Tarih;
                vm.Baslik = ilan.Baslik;
                vm.Sehir = ilan.Sehir;
                vm.Ilce = ilan.Ilce;
                vm.Ilantipi = ilan.Ilantipi;
                vm.UserId = ilan.UserId;
                vm.UserFullName = ilan.User.FullName;
                vm.UserTelNo = ilan.User.PhoneNumber;
                result.Add(vm);
                }
            }

            return result;
        }



        public void AddIlan(IlanVM vm, int xuserID)
        {
            Ilan model = new Ilan();
            vm.UserId = xuserID;
            model.Id = vm.Id;
            model.Aciklama =vm.Aciklama;
            model.Tarih = DateTime.UtcNow.AddHours(3);
            model.Baslik = vm.Baslik;
            model.Sehir = vm.Sehir;
            model.Ilce = vm.Ilce;
            model.Ilantipi = vm.Ilantipi;
            model.UserId = vm.UserId;
            _context.Ilans.Add(model);
            _context.SaveChanges();
        }


        public IlanVM GetEditIlan(int id)
        {
            var model = _context.Ilans.Find(id);
            var result = new IlanVM();

            result.Id = model.Id;
            result.Aciklama = model.Aciklama;
            result.Baslik = model.Baslik;
            result.Sehir = model.Sehir;
            result.Ilce = model.Ilce;
            result.Ilantipi= model.Ilantipi;
            result.Tarih = DateTime.UtcNow.AddHours(3);

            return result;

        }

        public void EditIlan(IlanVM vm)
        {
            var model = _context.Ilans.Find(vm.Id);
            model.Baslik = vm.Baslik;
            model.Sehir = vm.Sehir;
            model.Ilce = vm.Ilce;
            model.Ilantipi = vm.Ilantipi;
            model.Tarih = DateTime.UtcNow.AddHours(3);
            model.Aciklama =vm.Aciklama;


            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool DeleteIlan(int id)
        {
            var model = _context.Ilans.Find(id);
            if (model == null)
            {
                return false;
            }

            _context.Ilans.Remove(model);
            _context.SaveChanges(true);
            return true;
        }
    }
}
