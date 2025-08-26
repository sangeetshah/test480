using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Passports
{
    /// <summary>
    /// Represents an passport list model
    /// </summary>
    public partial record PassportListModel : BasePagedListModel<PassportModel>
    {
    }
}