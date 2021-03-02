﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpusIntakeBlazorApps.Pages
{
    public partial class DoesNotQualify : ComponentBase
    {
        [Inject] private ILogger<DoesNotQualify> _logger { get; set; }

        [Parameter] public string Title { get; set; }

        // Basic Lifecycle Functions
        //      There are Async versions of these        
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Title = "DoesNotQualify";
        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}
