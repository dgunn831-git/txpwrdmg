using OpusIntakeBlazorApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpusIntakeBlazorApps.Services
{
    public class Campaign : ICampaign
    {
        public Campaign()
        {
            Name = "Default Campaign";
            PncData = new Lead();
        }

        public string Name { get; set; }
        public Lead PncData { get; set; }

        public void SetCampaign(string campaignName)
        {
            if(!string.IsNullOrEmpty(campaignName))
                Name = campaignName;
        }
    }
}
