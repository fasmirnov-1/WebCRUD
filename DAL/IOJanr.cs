using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IOJanr: IDisposable
    {
        public List<Janr> GetAllJanrs()
        {
            List<Janr> janrs = null;

            using (MaterialEntities db = new MaterialEntities())
            {
                janrs = db.Janrs.ToList();
            }

            return janrs;
        }

        public Janr GetJanrByID(Guid JanrID)
        {
            Janr janr = null;

            using (MaterialEntities db = new MaterialEntities())
            {
                janr = db.Janrs.Where(x => x.JanrID == JanrID).FirstOrDefault();
            }

            return janr;
        }

        public void RemoveJanr(Guid JanrID)
        {
            using (MaterialEntities db = new MaterialEntities())
            {
                Janr janr = db.Janrs.Where(x => x.JanrID == JanrID).FirstOrDefault();
                db.Janrs.Remove(janr);

                db.SaveChanges();
            }
        }

        public void AddJanr(Janr janr)
        {
            using (MaterialEntities db = new MaterialEntities())
            {
                db.Janrs.Add(janr);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
