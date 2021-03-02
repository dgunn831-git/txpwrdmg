using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpusIntakeBlazorApps.Pages
{
    public partial class ContactInfo : ComponentBase
    {
        [Inject] private ILogger<ContactInfo> _logger { get; set; }

        public string Title { get; set; }

        // Basic Lifecycle Functions
        //      There are Async versions of these        
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Title = "ContactInfo";
        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}
