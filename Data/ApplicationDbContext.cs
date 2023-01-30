using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DynaParseWebsite.Models;

namespace DynaParseWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DynaParseWebsite.Models.Correspondence> Correspondence { get; set; }
        public DbSet<DynaParseWebsite.Models.GraveGrant> GraveGrant { get; set; }
    }
}
