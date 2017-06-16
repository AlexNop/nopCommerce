﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.CheckMoneyOrder.Models;
using Nop.Services.Localization;

namespace Nop.Plugin.Payments.CheckMoneyOrder.Components
{
    [ViewComponent(Name = "CheckMoneyOrder")]
    public class CheckMoneyOrderViewComponent : ViewComponent
    {
        private readonly CheckMoneyOrderPaymentSettings _checkMoneyOrderPaymentSettings;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public CheckMoneyOrderViewComponent(CheckMoneyOrderPaymentSettings checkMoneyOrderPaymentSettings,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            this._checkMoneyOrderPaymentSettings = checkMoneyOrderPaymentSettings;
            this._storeContext = storeContext;
            this._workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new PaymentInfoModel
            {
                DescriptionText = _checkMoneyOrderPaymentSettings.GetLocalizedSetting(x => x.DescriptionText, 
                    _workContext.WorkingLanguage.Id, _storeContext.CurrentStore.Id)
            };

            return View("~/Plugins/Payments.CheckMoneyOrder/Views/PaymentInfo.cshtml", model);
        }
    }
}
