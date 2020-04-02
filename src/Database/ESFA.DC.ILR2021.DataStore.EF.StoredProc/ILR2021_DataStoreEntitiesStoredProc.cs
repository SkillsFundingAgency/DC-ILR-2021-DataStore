using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESFA.DC.ILR2021.DataStore.EF.StoredProc
{
    public partial class ILR2021_DataStoreEntitiesStoredProc : DbContext
    {
        public ILR2021_DataStoreEntitiesStoredProc()
        {
        }

        public ILR2021_DataStoreEntitiesStoredProc(DbContextOptions<ILR2021_DataStoreEntitiesStoredProc> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=ESFA.DC.ILR.DataStore.Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
        }
    }
}
