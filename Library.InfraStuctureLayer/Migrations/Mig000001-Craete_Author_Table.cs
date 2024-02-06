using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Migrations
{
    [Migration(1)]
    internal class Mig000001_Craete_Author_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Authors").InSchema("Author")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(30);
        }
        public override void Down()
        {
            Delete.Table("Authors");
        }
    }
}
