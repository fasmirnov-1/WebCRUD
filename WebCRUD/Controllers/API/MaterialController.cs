using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DAL;

namespace WebCRUD.Controllers
{
    public class MaterialController : ApiController
    {
        [System.Web.Http.HttpGet]
        public Material[] GetAllMaterials()
        {
            List<Material> materials = null;
         
            using (IOMaterials io = new IOMaterials())
            {
                materials = io.GetAllMaterials();
            }

            return materials.ToArray();
        }

        [System.Web.Http.HttpGet()]
        public Material GetMaterialByID(Guid uuid)
        {
            Material material = null;
         
            using (IOMaterials io = new IOMaterials())
            {
                material = io.GetMaterialById(uuid);
            }

            return material;
        }

        [System.Web.Http.HttpDelete()]
        public void DeleteMaterialByID(Guid uuid)
        {
            using (IOMaterials io = new IOMaterials())
            {
                io.RemoveMaterial(uuid);
            }
        }

        [System.Web.Http.HttpPut()]
        public void AddMaterial([FromBody]Material material)
        {
            using (IOMaterials io = new IOMaterials())
            {
                io.AddMaterial(material);
            }
        }
    }
}
