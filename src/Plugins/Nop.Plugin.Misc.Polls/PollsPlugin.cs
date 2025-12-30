﻿using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Plugins;

namespace Nop.Plugin.Misc.Polls
{
    /// <summary>
    /// Main plugin class.
    /// </summary>
    public class PollsPlugin : BasePlugin, IMiscPlugin
    {
        private readonly IWebHelper _webHelper;

        public PollsPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/Poll/List";
        }

        public override async Task InstallAsync()
        {
            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await base.UninstallAsync();
        }
    }
}