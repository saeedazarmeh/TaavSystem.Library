using Library.DomainLayer.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Persistent.EF.EntityMap
{
    internal class BookEntityMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books", "Book");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Category).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(80).IsRequired();
            builder.Property(x => x.PublishYear).IsRequired();
        }
    }
}
