using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Healths
{
    /// <summary>
    /// Represents an health list model
    /// </summary>
    public partial record HealthListModel : BasePagedListModel<HealthModel>
    {
    }
}