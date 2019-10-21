using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deliverable2.Models
{
    public class UserVM
    {
        public SysUser user;

        public string GUID { get; private set; }
        public object GUIDExpiry { get; private set; }

        public void RefreshGUID(Project_DBEntities db)
        {
            db.Configuration.ProxyCreationEnabled = false;
            user.GUID = Guid.NewGuid().ToString();
            user.GUIDExpiry = DateTime.Now.AddMinutes(30);
            var guids = db.SysUsers.Where(usr => usr.GUID == user.GUID).Count();
            if (guids > 0)
                RefreshGUID(db);
            else
            {
                var u = db.SysUsers.Where(zz => zz.userID == user.userID).FirstOrDefault();
                db.Entry(u).CurrentValues.SetValues(user);
                db.SaveChanges();
            }

        }

        public bool IsLogedIn(Project_DBEntities db)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var guids = db.SysUsers.Where(usr => usr.GUID == user.GUID && usr.GUIDExpiry > DateTime.Now).Count();
            if (guids > 0)
                return true;
            return false;
        }

        public bool IsLogedIn(Project_DBEntities db, string userGUID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var guids = db.SysUsers.Where(usr => usr.GUID == userGUID && usr.GUIDExpiry > DateTime.Now).FirstOrDefault();
            if (guids != null)
                return true;
            return false;
        }
    }
}