using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpusIntakeBlazorApps.Shared
{
    public partial class InputTextLabel : ComponentBase
    {
        [Parameter] public string Name { get; set; }
        [Parameter] public string PlaceHolder { get; set; }
        [Parameter] public string BindValue { get; set; }

        private string bindVal { get; set; }


        private string classString { get => $"ub-input-item single text form_elem_{Name}"; }
    }
}
