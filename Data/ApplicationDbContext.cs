﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace StocksApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<WatchedStock> WatchedStocks { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<WatchedStock>(s =>
        {
            s.ToTable("WatchedStocks");
            s.HasKey(w => new { w.UserId, w.StockSymbol });
        });
    }
}
