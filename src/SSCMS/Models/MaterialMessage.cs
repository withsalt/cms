﻿using System.Collections.Generic;
using Datory;
using Datory.Annotations;

namespace SSCMS.Models
{
    [DataTable("siteserver_MaterialMessage")]
    public class MaterialMessage : Entity
    {
        [DataColumn]
        public int GroupId { get; set; }

        [DataIgnore]
        public List<MaterialMessageItem> Items { get; set; }
    }
}