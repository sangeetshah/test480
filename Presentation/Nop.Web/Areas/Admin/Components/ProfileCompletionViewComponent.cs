using Microsoft.AspNetCore.Mvc;
using Nop.Web.Areas.Admin.Models.Profiles;
using Nop.Web.Framework.Components;

namespace Nop.Web.Areas.Admin.Components
{
    /// <summary>
    /// Represents a view component that displays profile completion
    /// </summary>
    public partial class ProfileCompletionViewComponent : NopViewComponent
    {
        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the view component result
        /// </returns>
        public IViewComponentResult Invoke()
        {
            return View(new ProfileModel());
        }

        #endregion
    }
}