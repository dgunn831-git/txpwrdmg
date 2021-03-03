using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using OpusIntakeBlazorApps.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpusIntakeBlazorApps.Pages
{
    public partial class DoesNotQualify : ComponentBase
    {
        [Inject] private ILogger<DoesNotQualify> _logger { get; set; }
        [Inject] NavigationManager UriHelper { get; set; }
        [Inject] private ICampaign campaign { get; set; }

        public string Title { get; set; }

        // Basic Lifecycle Functions
        //      There are Async versions of these        
        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(campaign.Name))
                UriHelper.NavigateTo("/");
            
            base.OnInitialized();
            Title = "Texas Freeze 2021: Sorry you are not qualified to proceed";
        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}
