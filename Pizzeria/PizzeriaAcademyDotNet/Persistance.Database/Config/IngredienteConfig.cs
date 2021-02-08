using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    class IngredienteConfig
    {
        private EntityTypeBuilder<Ingrediente> entityTypeBuilder;

        public IngredienteConfig(EntityTypeBuilder<Ingrediente> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
