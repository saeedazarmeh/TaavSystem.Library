using Library.Entities.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistant.Persistent.EF.Books
{
    internal class BookEntityMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PublishYear).HasMaxLength(4).IsRequired();
            builder.HasMany(c => c.BorrowBooks).WithOne(b => b.Book).HasForeignKey(b => b.BookId);
        }
    }
}
