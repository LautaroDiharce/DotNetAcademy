using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    class EstadoConfig
    {
        private EntityTypeBuilder<Estado> entityTypeBuilder;

        public EstadoConfig(EntityTypeBuilder<Estado> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
