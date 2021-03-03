using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using OpusIntakeBlazorApps.Models;
using OpusIntakeBlazorApps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Blazored;
using Blazored.Modal;
using Blazored.Modal.Services;
using OpusIntakeBlazorApps.Shared;

namespace OpusIntakeBlazorApps.Pages
{
    public partial class ContactInfo : ComponentBase
    {
        [Inject] private ILogger<ContactInfo> _logger { get; set; }
        [Inject] public HttpClient http { get; set; }
        [Inject] NavigationManager UriHelper { get; set; }
        [Inject] public ICampaign campaign { get; set; }
        [Inject] public IModalService modal { get; set; }

        private string Title { get; set; }
        private List<KeyVal> stateList = new List<KeyVal>();
        private string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9_-]+\.[a-zA-Z0-9-.]{2,61}$";
        private string phonePattern = @"^(\+?1[ -]?)?\(?[2-9]\d\d\)?[ -]?[2-9]\d\d[ -]?\d{4}$";
        private string otherDetails { get; set; }
        
        public void FormSubmit()
        {
            campaign.PncData.LeadResponses.Add(new KeyValue("other_detials", otherDetails));
            campaign.PncData.CampaignName = "OpusIntakeForm";
            campaign.Submitted = false;
            var opts = new ModalOptions() { Animation = ModalAnimation.FadeIn(1), HideCloseButton = true, DisableBackgroundCancel = true  };
            var m = modal.Show<Confirmation>("Thank you for your submission", opts);
        }

        // Basic Lifecycle Functions
        //      There are Async versions of these        
        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(campaign.Name))
                UriHelper.NavigateTo("/");

            base.OnInitialized();
            Title = "Texas Freeze 2021: Qualified to submit your claim";
            var list = new List<string>() { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
            list.ForEach(x => { stateList.Add(new KeyVal(x, x)); });
        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}

