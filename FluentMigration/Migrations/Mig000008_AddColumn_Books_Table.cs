using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMigration.Migrations
{
    [Migration(8)]
    public class Mig000008_AddColumn_Books_Table : Migration
    {

        public override void Up()
        {
            Alter.Table("Books")
                .AddColumn("PublishYear").AsDateTime().NotNullable();
        }
        public override void Down()
        {
            Delete.Column("PublishYear").FromTable("Books");
        }
    }
}

