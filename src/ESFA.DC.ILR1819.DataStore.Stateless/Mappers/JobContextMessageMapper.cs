﻿using ESFA.DC.JobContext;
using ESFA.DC.Mapping.Interface;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Mappers
{
    public class JobContextMessageMapper : IMapper<JobContextMessage, JobContextMessage>
    {
        public JobContextMessage MapTo(JobContextMessage value)
        {
            return value;
        }

        public JobContextMessage MapFrom(JobContextMessage value)
        {
            return value;
        }
    }
}
