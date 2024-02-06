using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Migrations
{
    [Migration(7)]
    internal class Mig000007_AddColumn_Books_Table : Migration
    {

        public override void Up()
        {
            Alter.Table("Books")
                .AddColumn("BookCount").AsInt32().NotNullable();
        }
        public override void Down()
        {
            Delete.Column("BookCount").FromTable("Books");
        }
    }
}
