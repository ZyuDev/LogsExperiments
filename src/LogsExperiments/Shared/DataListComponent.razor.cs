using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogsExperiments.Shared
{
    public partial class DataListComponent: ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public IEnumerable<string> Source { get; set; }
    }
}
