using Microsoft.AspNetCore.Components;
using OpusIntakeBlazorApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpusIntakeBlazorApps.Services
{
    public class Campaign : ICampaign
    {
        [Inject] public IMessageService message { get; set; }

        public Campaign()
        {
            PncData = new Lead();
        }

        public string Name { get; set; }
        public Lead PncData { get; set; }
        public bool Submitted { get; set; }
        public string FormUrl { get; set; }

        public void SetCampaign(string campaignName)
        {
            if (!string.IsNullOrEmpty(campaignName))
                Name = campaignName;
            else
                Name = "OpusLeadForm";

            PncData.AccountName = Name;
        }
    }
}
