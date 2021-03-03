using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using OpusIntakeBlazorApps.Models;
using OpusIntakeBlazorApps.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpusIntakeBlazorApps.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject] public ICampaign _camp { get; set; }
        [Inject] NavigationManager UriHelper { get; set; }

        [Parameter] public string CampaignName { get; set; }

        public string Title { get; set; }

        public Lead lead = new Lead();
        public string damage { get; set; }
        public string claimType { get; set; }
        public string lossValue { get; set; }

        public Dictionary<string,object> GetAttributes(string id)
        {
            var ret = new Dictionary<string, object>();
            ret.Add("class", $"ub-input-item single form_elem_{id}");
            ret.Add("id", id);
            ret.Add("name", id);

            return ret;
        }

        public void FormSubmit()
        {
            if (damage == "Yes")
            {
                _camp.PncData.LeadResponses.Add(new KeyValue("damage", damage));
                _camp.PncData.LeadResponses.Add(new KeyValue("claimType", claimType));
                _camp.PncData.LeadResponses.Add(new KeyValue("lossValue", lossValue));

                UriHelper.NavigateTo("/contact");
            }
            else
                UriHelper.NavigateTo("/dnq");
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Title = "Texas Freeze 2021: Submit your claim for damages today.";

        }
        protected override void OnAfterRender(bool firstRender)
        {
            _camp.SetCampaign(CampaignName);
            base.OnAfterRender(firstRender);
        }
    }
}
