﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SSCMS.Configuration;
using SSCMS.Dto;
using SSCMS.Repositories;
using SSCMS.Services;

namespace SSCMS.Web.Controllers.Admin.Settings.Analysis
{
    [OpenApiIgnore]
    [Authorize(Roles = Types.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class AnalysisSiteContentController : ControllerBase
    {
        private const string Route = "settings/analysisSiteContent";

        private readonly IAuthManager _authManager;
        private readonly ISiteRepository _siteRepository;
        private readonly IStatRepository _statRepository;
        private readonly IAdministratorRepository _administratorRepository;

        public AnalysisSiteContentController(
            IAuthManager authManager,
            ISiteRepository siteRepository,
            IStatRepository statRepository,
            IAdministratorRepository administratorRepository
        )
        {
            _authManager = authManager;
            _siteRepository = siteRepository;
            _statRepository = statRepository;
            _administratorRepository = administratorRepository;
        }

        public class GetRequest
        {
            public int SiteId { get; set; }
            public string DateFrom { get; set; }
            public string DateTo { get; set; }
        }

        public class GetStat
        {
            public string Date { get; set; }
            public int Add { get; set; }
            public int Edit { get; set; }
        }

        public class GetAdminStat
        {
            public int AdminId { get; set; }
            public string Guid { get; set; }
            public string AdminName { get; set; }
            public int Add { get; set; }
            public int Edit { get; set; }
        }

        public class GetResult
        {
            public List<Cascade<int>> Sites { get; set; }
            public List<string> Days { get; set; }
            public List<int> AddCount { get; set; }
            public List<int> EditCount { get; set; }
            public IOrderedEnumerable<GetAdminStat> AdminStats { get; set; }
        }
    }
}
