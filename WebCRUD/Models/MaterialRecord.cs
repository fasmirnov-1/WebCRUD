using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCRUD.Models
{
    public class MaterialRecord
    {
        public Guid MaterialID { get; set; }
        public string Tkin { get; set; }
        public DateTime? DateEfir { get; set; }
        public string Title { get; set; }
        public double? Reaiting { get; set; }
    }
}