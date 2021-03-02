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

        public void formSubmit()
        {
            if (damage == "Yes")
            {
                _camp.PncData.CampaignAttributes.Add(new KeyValue("damage", damage));
                _camp.PncData.CampaignAttributes.Add(new KeyValue("claimType", claimType));
                _camp.PncData.CampaignAttributes.Add(new KeyValue("lossValue", lossValue));

                UriHelper.NavigateTo("/claim/contactinfo");
            }
            else
                UriHelper.NavigateTo("/claim/dnq");
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _camp.SetCampaign(CampaignName);
            Title = _camp.Name;

        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}
