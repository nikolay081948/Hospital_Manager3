using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Hospital_Manager.Configurations
{
    public class HosptalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasData(new Hospital
            {
                Id = 1,
                Name = "МБАЛ Казанлък",
                Address = "Казанлък",
                Email = "hospital1@gmail.com",
                PhoneNumber = "0888123456",
                BedsCount = 200,
                CreatedOn = new DateTime(2026, 1, 1),
                IsDeleted = false
            },
            new Hospital
            {
                Id = 2,
                Name = "УМБАЛ Стара Загора",
                Address = "Стара Загора",
                Email = "hospital2@gmail.com",
                PhoneNumber = "0888123457",
                BedsCount = 350,
                CreatedOn = new DateTime(2026, 1, 1),
                IsDeleted = false
            });
            
        }
    }
}
