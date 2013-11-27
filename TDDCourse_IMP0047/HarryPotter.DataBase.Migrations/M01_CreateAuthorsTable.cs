using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace HarryPotter.DataBase.Migrations
{
    [Migration(1)]
    public class M01_CreateAuthorsTable: Migration
    {
        public override void Down()
        {
            Delete.Table("authors");
        }

        public override void Up()
        {
            Create.Table("authors")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }
    }
}
