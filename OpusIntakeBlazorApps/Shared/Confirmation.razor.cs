using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using OpusIntakeBlazorApps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

namespace OpusIntakeBlazorApps.Shared
{
    public partial class Confirmation : ComponentBase, IDisposable
    {
        [Inject] public HttpClient http { get; set; }
        [Inject] NavigationManager UriHelper { get; set; }
        [Inject] public ICampaign campaign { get; set; }
        [Inject] public IMessageService message { get; set; }
        [Parameter] public bool showButton { get; set; }
        string formUrl = "http://apple.com";

        public void GoToForm()
        {
            UriHelper.NavigateTo(formUrl);
        }

        protected override void OnInitialized()
        {
            showButton = false;
            message.OnMessage += Message_OnMessage;

            base.OnInitialized();
        }

        protected async override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            
            var response = await http.PostAsJsonAsync("http://localhost:44386/import/opuspost", campaign.PncData);
            formUrl = await response.Content.ReadAsStringAsync();
            
            UriHelper.NavigateTo(formUrl);
            
            showButton = true;
            StateHasChanged();
        }

        private void Message_OnMessage(string obj)
        {
            if (obj == "ready")
                showButton = true;
        }

        public void Dispose()
        {
            message.OnMessage -= Message_OnMessage;
        }
    }
}
