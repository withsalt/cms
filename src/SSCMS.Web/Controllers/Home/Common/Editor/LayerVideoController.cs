﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SSCMS.Configuration;
using SSCMS.Repositories;
using SSCMS.Services;

namespace SSCMS.Web.Controllers.Home.Common.Editor
{
    [OpenApiIgnore]
    [Authorize(Roles = Types.Roles.User)]
    [Route(Constants.ApiHomePrefix)]
    public partial class LayerVideoController : ControllerBase
    {
        private const string RouteUploadVideo = "common/editor/layerVideo/actions/uploadVideo";
        private const string RouteUploadImage = "common/editor/layerVideo/actions/uploadImage";

        private readonly IAuthManager _authManager;
        private readonly IPathManager _pathManager;
        private readonly IVodManager _vodManager;
        private readonly IStorageManager _storageManager;
        private readonly ISiteRepository _siteRepository;

        public LayerVideoController(
            IAuthManager authManager,
            IPathManager pathManager,
            IVodManager vodManager,
            IStorageManager storageManager,
            ISiteRepository siteRepository
        )
        {
            _authManager = authManager;
            _pathManager = pathManager;
            _vodManager = vodManager;
            _storageManager = storageManager;
            _siteRepository = siteRepository;
        }

        public class UploadResult
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public string Url { get; set; }
        }
    }
}
