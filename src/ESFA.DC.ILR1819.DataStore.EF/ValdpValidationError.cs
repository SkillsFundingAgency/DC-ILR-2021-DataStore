﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ValdpValidationError
    {
        public int Ukprn { get; set; }
        public string ErrorString { get; set; }
        public string FieldValues { get; set; }
        public string LearnRefNumber { get; set; }
        public string RuleId { get; set; }
    }
}
