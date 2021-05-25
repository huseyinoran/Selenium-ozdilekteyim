using Microsoft.EntityFrameworkCore;
using ozdilekteyim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace  ozdilekteyim.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<KategoriAddresses> KategoriAddresses { get; set; }
        public DbSet<Markets> Markets { get; set; }
        public DbSet<ProductAddress> ProductAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<ProductsInBrands> ProductsInBrands { get; set; }
        public DbSet<EngProduct> EngProducts { get; set; }
        public DbSet<RusProduct> RusProducts { get; set; }
        public DbSet<ArapProduct> ArapProducts { get; set; }
        public DbSet<EngCategory> EngCategories { get; set; }
        public DbSet<RusCategory> RusCategories { get; set; }
        public DbSet<ArapCategory> ArapCategories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProductPoolDbozdilekteyim;Trusted_Connection=True;");
        }
    }
}
