using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMigration.Migrations
{
    [Migration(2)]
    public class Mig000002_Craete_Categories_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Categories")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Name").AsString(30);
        }

        public override void Down()
        {
            Delete.Table("Categories");
        }
    }
}
