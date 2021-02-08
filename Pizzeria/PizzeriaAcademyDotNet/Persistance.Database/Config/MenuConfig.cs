using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    class MenuConfig
    {
        private EntityTypeBuilder<Menu> entityTypeBuilder;

        public MenuConfig(EntityTypeBuilder<Menu> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
