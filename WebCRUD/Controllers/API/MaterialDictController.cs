using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebCRUD.Controllers
{
    public class MaterialDictController : ApiController
    {
        [HttpGet()]
        public MaterialDict[] GetAllMaterialDicts()
        {
            List<MaterialDict> materialDicts = null;

            using (IOMaterialDict materialDict = new IOMaterialDict())
            {
                materialDicts = materialDict.GetAllMaterialDict();
            }

            return materialDicts.ToArray();
        }

        [HttpGet()]
        public MaterialDict GetMaterialDictByID(Guid ID)
        {
            MaterialDict materialDict = null;

            using (IOMaterialDict ioMaterialDict = new IOMaterialDict())
            {
                materialDict = ioMaterialDict.GetMaterialDictByID(ID);
            }

            return materialDict;
        }

        [HttpDelete]
        public void DeleteMaterialDictByID(Guid ID)
        {
            using (IOMaterialDict materialDict = new IOMaterialDict())
            {
                materialDict.RemoveMaterialDictByID(ID);
            }
        }

        [HttpPut]
        public void AddMaterialDict(MaterialDict materialDict)
        {
            using (IOMaterialDict ioMaterialDict = new IOMaterialDict())
            {
                ioMaterialDict.AddMaterialDict(materialDict);
            }
        }
    }
}