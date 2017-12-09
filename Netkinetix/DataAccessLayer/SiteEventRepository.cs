using Netkinetix.Models;

using System;

using System.Collections.Generic;

using System.Data.Entity;

using System.Linq;

using System.Web;

namespace Netkinetix.DataAccessLayer
    // Logic that we can do with DB
{

    public class SiteEventRepository

    {

        private NetkinetixContext db = new NetkinetixContext();



        public void Create(SiteEvent siteEvent)

        {

            db.SiteEvent.Add(siteEvent);



        }



        public IEnumerable<SiteEvent> GetAll()

        {

            return db.SiteEvent.ToList();

        }



        public SiteEvent GetOne(int seId)

        {

            return db.SiteEvent.Find(seId);

        }



        public void Update(SiteEvent siteEvent)

        {

            db.Entry(siteEvent).State = EntityState.Modified;

        }



        public void Delete(int seId)

        {

            var deleteSiteEvent = db.SiteEvent.Find(seId);

            db.Entry(deleteSiteEvent).State = EntityState.Deleted;

        }



        public void Save()

        {

            db.SaveChanges();

        }



        private bool disposed = false;



        protected virtual void Dispose(bool disposing)

        {

            if (!this.disposed)

            {

                if (disposing)

                {

                    db.Dispose();

                }

            }

            this.disposed = true;

        }



        public void Dispose()

        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }

    }
}