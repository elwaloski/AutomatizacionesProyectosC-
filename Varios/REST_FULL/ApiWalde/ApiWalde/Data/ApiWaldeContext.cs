using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiWalde.Models;

namespace ApiWalde.Data
{
    public class ApiWaldeContext : DbContext
    {
        public ApiWaldeContext (DbContextOptions<ApiWaldeContext> options)
            : base(options)
        {
        }
        public DbSet<ApiWalde.Models.DteRangFoli> DteRangFoli { get; set; } = default!;
        public DbSet<ApiWalde.Models.ParaEmpr> ParaEmpr { get; set; } = default!;
        public DbSet<ApiWalde.Models.ConsultaDTE> ConsultaDTE { get; set; } = default!;
        public DbSet<ApiWalde.Models.ConsultaBEL> ConsultaBEL { get; set; } = default!;
    }
}
