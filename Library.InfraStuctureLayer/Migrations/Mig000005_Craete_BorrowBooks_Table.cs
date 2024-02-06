using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Migrations
{
    [Migration(5)]
    internal class Mig000005_Craete_BorrowBooks_Table:Migration
    {
        public override void Up()
        {
            Create.Table("BorrowBooks").InSchema("User")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DurationPerDay").AsInt32()
            .WithColumn("Start").AsDateTime()
            .ForeignKey("BookId", "books", "Id")
            .ForeignKey("UserId", "Users", "Id");
        }

        public override void Down()
        {
            Delete.Table("BorrowBooks");
        }
    }
}
