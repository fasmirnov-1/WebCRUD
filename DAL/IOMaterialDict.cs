using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IOMaterialDict: IDisposable
    {
        public List<MaterialDict>GetAllMaterialDict()
        {
            List<MaterialDict> materialDicts = null;

            using (MaterialEntities db = new MaterialEntities())
            {
                materialDicts = db.MaterialDicts.ToList();
            }

            return materialDicts;
        }

        public MaterialDict GetMaterialDictByID(Guid MaterialID)
        {
            MaterialDict materialDict = null;

            using (MaterialEntities db = new MaterialEntities())
            {
                materialDict = db.MaterialDicts.ToList().Where(x => x.MaterialID == MaterialID).FirstOrDefault();
            }

            return materialDict;
        }

        public void RemoveMaterialDictByID(Guid MaterialID)
        {
            using (MaterialEntities db = new MaterialEntities())
            {
                MaterialDict materialDict = db.MaterialDicts.ToList().Where(x => x.MaterialID == MaterialID).FirstOrDefault();
                db.MaterialDicts.Remove(materialDict);

                db.SaveChanges();
            }
        }

        public void AddMaterialDict(MaterialDict materialDict)
        {
            using (MaterialEntities db = new MaterialEntities())
            {
                db.MaterialDicts.Add(materialDict);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
