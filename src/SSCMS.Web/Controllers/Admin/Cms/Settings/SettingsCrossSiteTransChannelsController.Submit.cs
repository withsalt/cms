﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Dto;
using SSCMS.Utils;
using SSCMS.Core.Utils;
using System.Collections.Generic;

namespace SSCMS.Web.Controllers.Admin.Cms.Settings
{
    public partial class SettingsCrossSiteTransChannelsController
    {
        [HttpPost, Route(Route)]
        public async Task<ActionResult<List<int>>> Submit([FromBody] SubmitRequest request)
        {
            if (!await _authManager.HasSitePermissionsAsync(request.SiteId,
                MenuUtils.SitePermissions.SettingsCrossSiteTransChannels))
            {
                return Unauthorized();
            }

            var site = await _siteRepository.GetAsync(request.SiteId);
            if (site == null) return this.Error("无法确定内容对应的站点");

            await _translateRepository.DeleteAsync(request.SiteId, request.ChannelId);

            if (request.Translates != null && request.Translates.Count > 0)
            {
                foreach (var translate in request.Translates)
                {
                    await _translateRepository.InsertAsync(translate);
                }
            }

            await _authManager.AddSiteLogAsync(request.SiteId, "修改跨站转发设置");

            var channel = await _channelRepository.GetAsync(request.ChannelId);
            var expendedChannelIds = new List<int>
            {
                request.SiteId
            };
            if (!expendedChannelIds.Contains(channel.ParentId))
            {
                expendedChannelIds.Add(channel.ParentId);
            }

            return expendedChannelIds;
        }
    }
}