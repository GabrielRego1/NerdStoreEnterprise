﻿using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NSE.Carrinho.WebAPI.Model;
using System.Linq;

namespace NSE.Carrinho.WebAPI.Data
{
    public class CarrinhoContext : DbContext
    {
        public CarrinhoContext(DbContextOptions<CarrinhoContext> options)
         : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<CarrinhoItem> CarrinhoItens { get; set; }
        public DbSet<CarrinhoCliente> CarrinhoCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarrinhoContext).Assembly);

            //Habilitando delete cascate (Ao deletar o CarrinhoCliente, tambem ira apagar o CarrinhoItens relacionado )
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }
}
