using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    class TamañoConfig
    {
        private EntityTypeBuilder<Tamaño> entityTypeBuilder;

        public TamañoConfig(EntityTypeBuilder<Tamaño> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
