using CodefirstRelationEFCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CodefirstRelationEFCore.Data
{
    public class PatikaSecondDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public PatikaSecondDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating: Modellerin özelliklerini ve ilişkilerini belirlediğimiz yerdir.
        {
            // User varlığı için yapılandırmalar
            modelBuilder.Entity<User>(entity =>
            {
                // Id özelliğini birincil anahtar olarak belirliyoruz.
                entity.HasKey(e => e.Id);

                // UserName özelliğini zorunlu hale getiriyoruz ve maksimum uzunluğunu 50 karakterle sınırlıyoruz.
                entity.Property(e => e.UserName)
                      .IsRequired() // Bu alanın boş olamayacağını belirtir.
                      .HasMaxLength(50); // Bu alanın maksimum uzunluğunu 50 karakter olarak ayarlar.

                // Email özelliğini zorunlu hale getiriyoruz ve maksimum uzunluğunu 128 karakterle sınırlıyoruz.
                entity.Property(e => e.Email)
                      .IsRequired() // Bu alanın boş olamayacağını belirtir.
                      .HasMaxLength(128); // Bu alanın maksimum uzunluğunu 128 karakter olarak ayarlar.

                // User varlığının birden fazla Post'a sahip olabileceğini belirtiyoruz.
                entity.HasMany(x => x.Posts) // User varlığının Posts koleksiyonu ile ilişkisini tanımlar.
                      .WithOne(x => x.User) // Her Post'un bir User'a ait olduğunu belirtir.
                      .HasForeignKey(x => x.UserId) // UserId özelliğinin Post tablosundaki dış anahtar olduğunu belirtir.
                      .OnDelete(DeleteBehavior.Cascade); // Bir User silindiğinde, ona ait tüm Post'ların da silinmesini sağlar.
            });

            // Post varlığı için yapılandırmalar
            modelBuilder.Entity<Post>(entity =>
            {
                // Id özelliğini birincil anahtar olarak belirliyoruz.
                entity.HasKey(e => e.Id);

                // Title özelliğini zorunlu hale getiriyoruz.
                entity.Property(e => e.Title)
                      .IsRequired(); // Bu alanın boş olamayacağını belirtir.

                // Content özelliğini zorunlu hale getiriyoruz.
                entity.Property(e => e.Content)
                      .IsRequired(); // Bu alanın boş olamayacağını belirtir.

                // UserId özelliğini zorunlu hale getiriyoruz.
                entity.Property(e => e.UserId)
                      .IsRequired(); // Bu alanın boş olamayacağını belirtir.

                // Post varlığının bir User ile ilişkili olduğunu belirtiyoruz.
                entity.HasOne(x => x.User) // Her Post'un bir User ile ilişkili olduğunu belirtir.
                      .WithMany(x => x.Posts) // User varlığının birden fazla Post'a sahip olabileceğini belirtir.
                      .HasForeignKey(x => x.UserId); // UserId özelliğinin Post tablosundaki dış anahtar olduğunu belirtir.
            });
        }

    }
}