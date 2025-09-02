using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Finances
{
    /// <summary>
    /// Represents an finance list model
    /// </summary>
    public partial record FinanceListModel : BasePagedListModel<FinanceModel>
    {
    }
}