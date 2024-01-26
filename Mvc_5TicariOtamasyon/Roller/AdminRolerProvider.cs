using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using Context = Mvc_5TicariOtamasyon.Models.sınıflar.Context;

namespace Mvc_5TicariOtamasyon.Roller
{
      
    public class AdminRolerProvider : RoleProvider //Miras Alma (1.ADIM)
    {
      
        //(2.ADIM)
        //AŞAĞIDAKİ KISIMIMLARI AMPULÜN ÜSTÜNE GELİP SOYUT SINIF EKLE DİYEREK OTAMATİK EKLEMİŞ OLUYORUZ

        //3.ADIM
        //Web Config dosyasında eklemeler yapacağız
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        //işlem yapacağımız alan burası
        //4.ADIM
        public override string[] GetRolesForUser(string username)
        {
            Context c = new Context();
            var k = c.admins.FirstOrDefault(x => x.KullaniciAd == username);
            return new string[] { k.yetki };

            
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}