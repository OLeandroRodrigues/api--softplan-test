using Microsoft.EntityFrameworkCore;
using SoftPllan.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Test.Data
{
    public class JurosMap : EntityMap
    {
        public JurosMap(ModelBuilder builder)
        {
            builder.Entity<Juros>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Taxa);
            });
        }
    }
}
