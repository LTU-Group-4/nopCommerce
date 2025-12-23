using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Plugins;
using Nop.Services.Localization;

namespace Nop.Plugin.Misc.Polls
{
    /// <summary>
    /// Main plugin class.
    /// Handles installation and uninstallation logic.
    /// </summary>
    public class PollsPlugin : BasePlugin
    {
        private readonly IWebHelper _webHelper;

        public PollsPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        /// <summary>
        /// Gets the configuration page URL.
        /// Redirects the "Configure" button in the plugin list to our admin page.
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/Poll/List";
        }

        public override async Task InstallAsync()
        {
            // Database tables are created via Migrations automatically.
            // Here you can add localization resources if needed.
            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            // Database tables are removed via Migrations automatically (if implemented).
            await base.UninstallAsync();
        }
    }
}