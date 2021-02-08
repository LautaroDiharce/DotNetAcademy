using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    class PedidoConfig
    {
        public PedidoConfig(EntityTypeBuilder<Pedido> entityBuilder) {
            entityBuilder.HasKey(x => x.id);
        }
    }
}

