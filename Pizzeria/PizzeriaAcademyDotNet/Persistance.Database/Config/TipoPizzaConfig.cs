using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    class TipoPizzaConfig
    {
        private EntityTypeBuilder<TipoPizza> entityTypeBuilder;

        public TipoPizzaConfig(EntityTypeBuilder<TipoPizza> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
