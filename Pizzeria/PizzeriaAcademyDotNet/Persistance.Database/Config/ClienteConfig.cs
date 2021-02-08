using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Config
{
    class ClienteConfig
    {
        public ClienteConfig(EntityTypeBuilder<Cliente> entityTypeBuilder)
        {
        }
    }
}
