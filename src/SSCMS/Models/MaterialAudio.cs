﻿using Datory;
using Datory.Annotations;

namespace SSCMS.Models
{
    [DataTable("siteserver_MaterialAudio")]
    public class MaterialAudio : Entity
    {
        [DataColumn]
        public int GroupId { get; set; }

        [DataColumn]
        public string Title { get; set; }

        [DataColumn]
        public string FileType { get; set; }

        [DataColumn]
        public string Url { get; set; }
    }
}