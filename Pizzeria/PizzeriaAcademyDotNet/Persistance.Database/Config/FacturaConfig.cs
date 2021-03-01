using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    public class FacturaConfig
    {
        private EntityTypeBuilder<Factura> entityTypeBuilder;

        public FacturaConfig(EntityTypeBuilder<Factura> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
