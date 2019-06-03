using System;
using System.Collections.Generic;
using MumanalPG.Models.RRHH;

namespace MumanalPG.Models.Correspondencia.DTO
{
    public class AreasFunTreeDTO
    {
        public int funId { get; set; }
        public int areaId { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public string parent { get; set; }

        public string[] li_attr { get; set; }
        public string[] a_attr { get; set; }

        public Object state { get; set; } = new {opened = false, disabled = false, selected = false};
    }
}