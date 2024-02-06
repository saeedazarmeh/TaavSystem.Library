using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Migrations
{
    [Migration(3)]
    internal class Mig000003_Craete_Books_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Books").InSchema("Book")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(30)
            .ForeignKey("AuthorId", "Authors", "Id")
            .ForeignKey("CategoryId", "Categories", "Id");
        }

        public override void Down()
        {
            Delete.Table("Books");
        }

    }
}
