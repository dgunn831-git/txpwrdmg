using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using OpusIntakeBlazorApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpusIntakeBlazorApps.Shared
{
    public partial class InputSelectLabel : ComponentBase
    {
        [Parameter] public string Name { get; set; }
        [Parameter] public string PlaceHolder { get; set; }
        [Parameter] public string BindValue { get; set; }
        [Parameter] public List<KeyVal> DataSource { get; set; }

        private string classString { get=>$"ub-input-item single form_elem_{Name}"; }
    }
}
