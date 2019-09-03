using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureServices.Configurations
{
    public class Bill_Configuration : IEntityTypeConfiguration<Bill_InfraModel>
    {
        public void Configure(EntityTypeBuilder<Bill_InfraModel> builder)
        {
            builder.ToTable("Bills");

            builder.HasKey(_ => _.Id);
        }
    }
}