using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMigration.Migrations
{
    [Migration(6)]
    public class Mig000006_AddColumn_BorrowBooks_Table : Migration
    {
        public override void Up()
        {
            Alter.Table("BorrowBooks")
                .AddColumn("Status").AsInt32().NotNullable();
        }
        public override void Down()
        {
            Delete.Column("Status").FromTable("BorrowBooks");
        }


    }
}
