using Library.DomainLayer.Author;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Persistent.EF.EntityMap
{
    internal class AuthorEntityMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors", "Author");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(30).IsRequired();
            builder.HasMany(c => c.Books).WithOne(b => b.Author).HasForeignKey(b => b.AuthorId);
        }
    }
}
