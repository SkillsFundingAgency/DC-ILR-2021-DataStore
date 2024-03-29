﻿using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Jet;
using ESFA.DC.ILR.DataStore.Access.Interface;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Access
{
    public class InvalidGenerateSchema : IGenerateSchema
    {
        public async Task Generate(string connectionString, CancellationToken cancellationToken)
        {
            var context = new InvalidMdbContext(new DbContextOptionsBuilder<InvalidMdbContext>().UseJet(connectionString).Options);

            await context.Database.MigrateAsync(cancellationToken);
        }
    }
}
