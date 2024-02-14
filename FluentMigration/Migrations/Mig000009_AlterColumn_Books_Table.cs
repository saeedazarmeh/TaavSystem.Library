using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMigration.Migrations
{
    [Migration(9)]
    public class Mig000009_AlterColumn_Books_Table:Migration
    {
        public override void Up()
        {
            Alter.Table("Books")
                .AlterColumn("PublishYear").AsString(4).NotNullable();
        }
        public override void Down()
        {
            Alter.Table("Books")
               .AlterColumn("PublishYear").AsDateTime().NotNullable();
        }
    }
}
