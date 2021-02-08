using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    class VariedadConfig
    {
        private EntityTypeBuilder<Variedad> entityTypeBuilder;

        public VariedadConfig(EntityTypeBuilder<Variedad> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
