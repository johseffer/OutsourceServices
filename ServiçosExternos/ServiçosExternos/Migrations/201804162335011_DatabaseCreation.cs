namespace ServiçosExternos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(),
                        ServiceType = c.String(),
                        ClienteId = c.Int(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Fornecedors", t => t.FornecedorId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "FornecedorId", "dbo.Fornecedors");
            DropForeignKey("dbo.Services", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Services", new[] { "FornecedorId" });
            DropIndex("dbo.Services", new[] { "ClienteId" });
            DropTable("dbo.Fornecedors");
            DropTable("dbo.Services");
            DropTable("dbo.Clientes");
        }
    }
}
