using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Works
{
    /// <summary>
    /// Represents an work list model
    /// </summary>
    public partial record WorkListModel : BasePagedListModel<WorkModel>
    {
    }
}