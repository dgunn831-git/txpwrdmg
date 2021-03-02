using OpusIntakeBlazorApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpusIntakeBlazorApps.Services
{
    public interface ICampaign
    {
        public string Name { get; set; }
        public Lead PncData { get; set; }

        public void SetCampaign(string campaignName);
    }
}
