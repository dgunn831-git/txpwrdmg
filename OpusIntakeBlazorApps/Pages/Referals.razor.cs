using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using OpusIntakeBlazorApps.Models;
using OpusIntakeBlazorApps.Services;
using OpusIntakeBlazorApps.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpusIntakeBlazorApps.Pages
{
    public partial class Referals : ComponentBase
    {
        [Inject] public ICampaign _camp { get; set; }
        [Inject] NavigationManager UriHelper { get; set; }
        [Inject] public IModalService modal { get; set; }

        [Parameter] public string CampaignName { get; set; }

        public string Title { get; set; }

        public Lead lead = new Lead();
        public string damage { get; set; }
        public string claimType { get; set; }
        public string lossValue { get; set; }

        public Dictionary<string, object> GetAttributes(string id)
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

        void ContactSrc()
        {
            ShowModal(
                "How did we get your name?",
                "Someone you know, possibly a family member, friend, neighbor or co-worker sent you this information, believing you might be interested and benefit from it as they are.  The first step is to receive a free claim review of your experience with regard to the Texas Winter Power Outage, see if you qualify, and your options for a legal recovery and possible compensation for damages.");
        }
        void WhoWeAre()
        {
            ShowModal(
                "Who is the Legal Assist Group and the Attorneys Involved?",
                "With the large numbers of claims being submitted into the potential settlement , the selected law firms are utilizing the Legal Assist Group to contact, screen, and assist all qualified applicants to help get them through the process.");
        }
        void Cost()
        {
            ShowModal(
                "Does this cost anything?",
                "The Legal Assist Group is not on commission and does NOT charge the claimants for any of their services.   A law firm will submit a claim on your behalf and will fight to get you the largest cash settlement possible.   The law firms are paid only if you receive a settlement.");
        }
        void ShowModal(string title, string desc)
        {
            var prms = new ModalParameters();
            prms.Add("Description", desc);

            var opts = new ModalOptions() { Animation = ModalAnimation.FadeIn(1) };
            var m = modal.Show<FAQ>(title, prms, opts);
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
