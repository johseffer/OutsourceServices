namespace ServiçosExternos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Date", c => c.DateTime());
        }
    }
}
