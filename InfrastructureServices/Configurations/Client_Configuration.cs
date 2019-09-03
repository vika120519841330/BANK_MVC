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
    public class Client_Configuration : IEntityTypeConfiguration<Client_InfraModel>
    {
        public void Configure(EntityTypeBuilder<Client_InfraModel> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(_ => _.Id);
        }
    }
}
