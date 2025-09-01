using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Works;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Works;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Works;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class WorkController : BaseAdminController
    {
        #region Fields

        protected readonly IWorkModelFactory _workModelFactory;
        protected readonly IWorkService _workService;
        protected readonly INotificationService _notificationService;
        protected readonly ILocalizationService _localizationService;
        protected readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public WorkController(IWorkModelFactory workModelFactory,
                              IWorkService workService,
                              INotificationService notificationService,
                              ILocalizationService localizationService,
                              IWorkContext workContext)
        {
            _workModelFactory = workModelFactory;
            _workService = workService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [CheckPermission(StandardPermission.Work.ACCESS_WORK)]
        public virtual async Task<IActionResult> List()
        {
            //prepare model
            var model = await _workModelFactory.PrepareWorkSearchModelAsync(new WorkSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Work.ACCESS_WORK)]
        public virtual async Task<IActionResult> List(WorkSearchModel searchModel)
        {
            //prepare model
            var model = await _workModelFactory.PrepareWorkListModelAsync(searchModel);

            return Json(model);
        }

        [CheckPermission(StandardPermission.Education.ACCESS_EDUCATION)]
        public virtual async Task<IActionResult> Create()
        {
            //prepare model
            var model = await _workModelFactory.PrepareWorkModelAsync(new WorkModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        [CheckPermission(StandardPermission.Work.ACCESS_WORK)]
        public virtual async Task<IActionResult> Create(WorkModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var work = model.ToEntity<Work>();

                work.CreatedAt = DateTime.UtcNow;

                await _workService.InsertWorkAsync(work);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Work.Created"));

                return continueEditing ? RedirectToAction("Edit", new { id = work.Id }) : RedirectToAction("List");
            }

            //prepare model
            model = await _workModelFactory.PrepareWorkModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [CheckPermission(StandardPermission.Work.ACCESS_WORK)]
        public virtual async Task<IActionResult> Edit(int id)
        {
            //try to get an work with the specified id
            var work = await _workService.GetWorkByIdAsync(id);
            if (work == null)
                return RedirectToAction("List");

            //prepare model
            var model = await _workModelFactory.PrepareWorkModelAsync(null, work);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [CheckPermission(StandardPermission.Work.ACCESS_WORK)]
        public virtual async Task<IActionResult> Edit(WorkModel model, bool continueEditing)
        {
            //try to get an work with the specified id
            var work = await _workService.GetWorkByIdAsync(model.Id);
            if (work == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                work = model.ToEntity(work);

                var customer = await _workContext.GetCurrentCustomerAsync();

                work.UpdatedAt = DateTime.UtcNow;
                work.UpdatedBy = customer.Email;                

                await _workService.UpdateWorkAsync(work);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Work.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = work.Id });
            }

            //prepare model
            model = await _workModelFactory.PrepareWorkModelAsync(model, work);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Work.ACCESS_WORK)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            //try to get an work with the specified id
            var work = await _workService.GetWorkByIdAsync(id);
            if (work == null)
                return RedirectToAction("List");

            await _workService.DeleteWorkAsync(work);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Work.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Work.ACCESS_WORK)]
        public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            var works = await _workService.GetWorksByIdsAsync(selectedIds.ToArray());
            if (works.Any())
                await _workService.DeleteWorksAsync(works);

            return Json(new { Result = true });
        }

        #endregion
    }
}