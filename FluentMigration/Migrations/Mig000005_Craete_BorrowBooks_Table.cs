using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMigration.Migrations
{
    [Migration(5)]
    public class Mig000005_Craete_BorrowBooks_Table : Migration
    {
        public override void Up()
        {
            Create.Table("BorrowBooks")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DurationPerDay").AsInt32()
            .WithColumn("Start").AsDateTime()
            .WithColumn("BookId").AsInt32()
            .WithColumn("UserId").AsInt32();
            Create.ForeignKey("FK_BorrowBook_Books").FromTable("BorrowBooks").ForeignColumn("BookId")
                .ToTable("Books").PrimaryColumns("Id");
            Create.ForeignKey("FK_BorrowBook_Users").FromTable("BorrowBooks").ForeignColumn("UserId")
                .ToTable("Users").PrimaryColumns("Id");
        }

        public override void Down()
        {
            Delete.Table("BorrowBooks");
        }
    }
}
