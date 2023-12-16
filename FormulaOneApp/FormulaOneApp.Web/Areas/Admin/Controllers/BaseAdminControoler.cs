using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneApp.Web.Areas.Admin.Controllers
{
    [Authorize (Roles = "Admin")]
    [Area("Admin")]
    public class BaseAdminControoler : Controller
    {
    }
}
