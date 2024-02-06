using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Migrations
{
    [Migration(4)]
    internal class Mig000004_Craete_Users_Table:Migration
    {
        public override void Up()
        {
            Create.Table("Users").InSchema("User")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(80)
            .WithColumn("Email").AsString(50)
            .WithColumn("CreationAt").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}
