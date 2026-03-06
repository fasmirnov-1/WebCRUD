using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IOMaterials: IDisposable
    {
        public List<Material> GetAllMaterials()
        {
            List<Material>materials = null;

            using (MaterialEntities db = new MaterialEntities())
            {
                materials = db.Materials.ToList();
            }

            return materials;
        }

        public Material GetMaterialById(Guid ID)
        {
            Material material = null;

            using (MaterialEntities db = new MaterialEntities())
            {
                material = db.Materials.ToList().Where(x => x.MaterialID == ID).FirstOrDefault();
            }

            return material;
        }

        public void RemoveMaterial(Guid ID)
        {
            using (MaterialEntities db = new MaterialEntities())
            {
                Material material = db.Materials.ToList().Where(x => x.MaterialID == ID).FirstOrDefault();
                db.Materials.Remove(material);
                db.SaveChanges();
            }
        }

        public void AddMaterial(Material Mtreal)
        {
            using (MaterialEntities db = new MaterialEntities())
            {
                db.Materials.Add(Mtreal);
                db.SaveChanges();
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
