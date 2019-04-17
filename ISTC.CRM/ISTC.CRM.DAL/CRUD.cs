using System;
using System.Collections.Generic;
using System.Text;
using ISTC.CRM.DAL.Models;

namespace ISTC.CRM
{
    public static class CRUD
    {
        public static void Create(User user)
        {
            using (CRMdbContext db = new CRMdbContext())
            {
                db.User.Add(user);
                db.SaveChanges();
            }
        }

        public static User Read(int id)
        {
            using (CRMdbContext db = new CRMdbContext())
            {
                foreach (User user in db.User)
                {
                    if (user.IdUser == id)
                        return user;
                }
                return null;
            }
        }

        public static void Update(User user)
        {
            using (CRMdbContext db = new CRMdbContext())
            {
                db.User.Update(user);
                db.SaveChanges();
            }
        }

        public static void Delete(User user)
        {
            using (CRMdbContext db = new CRMdbContext())
            {
                db.User.Remove(user);
                db.SaveChanges();
            }
        }
    }
}