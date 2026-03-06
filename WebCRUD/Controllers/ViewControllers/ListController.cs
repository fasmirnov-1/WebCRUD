using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DAL;
using WebCRUD.Models;

namespace WebCRUD.Controllers.ViewControllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            List<MaterialRecord> materialRecords = new List<MaterialRecord>();

            using (IOMaterials materials = new IOMaterials())
            {
                materials.GetAllMaterials().ForEach(x => {
                    materialRecords.Add(new MaterialRecord()
                    {
                        MaterialID = x.MaterialID,
                        Tkin = x.Tkin,
                        DateEfir = x.DateEfir,
                        Title = x.Title,
                        Reaiting = x.Raiting
                    });
                });
            }

            return View(materialRecords);
        }

        public ActionResult AddForm()
        {
            MaterialRecord materialRecord = new MaterialRecord();

            return View(materialRecord);
        }
    }
}