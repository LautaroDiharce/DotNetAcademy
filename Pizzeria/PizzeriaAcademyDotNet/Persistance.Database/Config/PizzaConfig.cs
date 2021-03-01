using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    public class PizzaConfig
    {
        private EntityTypeBuilder<Pizza> entityTypeBuilder;

        public PizzaConfig(EntityTypeBuilder<Pizza> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
