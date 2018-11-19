namespace ServiçosExternos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "ServiceType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "ServiceType", c => c.String());
        }
    }
}
