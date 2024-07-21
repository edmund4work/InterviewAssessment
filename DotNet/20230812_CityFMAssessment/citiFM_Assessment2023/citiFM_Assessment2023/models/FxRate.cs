using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace citiFM_Assessment2023.models
{
    public class FxRate
    {
        public string sourceCurrency { get; set; }
        public string targetCurrency { get; set; }
        public decimal rate { get; set; }
    }
}