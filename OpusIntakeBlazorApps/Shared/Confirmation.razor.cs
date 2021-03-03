using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpusIntakeBlazorApps.Models;
using OpusIntakeBlazorApps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

namespace OpusIntakeBlazorApps.Shared
{
    public partial class Confirmation : ComponentBase
    {
        [Inject] NavigationManager UriHelper { get; set; }
        [Inject] public ICampaign campaign { get; set; }

        public void GoToForm()
        {
            UriHelper.NavigateTo(campaign.FormUrl);
        }
    }
}
