using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Migrations
{
    [Migration(2)]
    internal class Mig000002_Craete_Categories_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Categories").InSchema("Category")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Name").AsString(30);
        }

        public override void Down()
        {
            Delete.Table("Categories");
        }
    }
}
