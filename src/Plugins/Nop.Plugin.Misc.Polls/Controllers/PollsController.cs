using Microsoft.AspNetCore.Mvc;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.Polls.Controllers;

[AutoValidateAntiforgeryToken]
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class PollsController : BasePluginController
{
    #region Fields

    private readonly IPermissionService _permissionService;

    #endregion

    #region Ctor 

    public PollsController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    #endregion

    #region Methods

    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public virtual IActionResult Configure()
    {
        return View("~/Plugins/Misc.Polls/Views/Configure.cshtml");
    }

    #endregion
}
