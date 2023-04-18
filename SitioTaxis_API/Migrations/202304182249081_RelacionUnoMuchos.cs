namespace SitioTaxis_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionUnoMuchos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        AdministradorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        NumeroTelefono = c.String(nullable: false),
                        CorreoElecronico = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdministradorID);
            
            CreateTable(
                "dbo.AdministradorSitio",
                c => new
                    {
                        AdministradorSitioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        NumeroTelefono = c.String(nullable: false),
                        CorreoElectronico = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        SitioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdministradorSitioID)
                .ForeignKey("dbo.Sitio", t => t.SitioID)
                .Index(t => t.SitioID);
            
            CreateTable(
                "dbo.Sitio",
                c => new
                    {
                        SitioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        HorarioAtencion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SitioID);
            
            CreateTable(
                "dbo.Checador",
                c => new
                    {
                        ChecadorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        NumeroTelefono = c.String(nullable: false),
                        CorreoElectronico = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        SitioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChecadorID)
                .ForeignKey("dbo.Sitio", t => t.SitioID)
                .Index(t => t.SitioID);
            
            CreateTable(
                "dbo.Chofer",
                c => new
                    {
                        ChoferID = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        NumeroLicencia = c.String(nullable: false),
                        NumeroTelefono = c.String(nullable: false),
                        CorreoElectronico = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        SitioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChoferID)
                .ForeignKey("dbo.Sitio", t => t.SitioID)
                .Index(t => t.SitioID);
            
            CreateTable(
                "dbo.Taxi",
                c => new
                    {
                        TaxiID = c.Int(nullable: false, identity: true),
                        NumeroPlaca = c.String(nullable: false),
                        Marca = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
                        Year = c.String(nullable: false),
                        Horario = c.String(nullable: false),
                        Estatus = c.String(nullable: false),
                        SitioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaxiID)
                .ForeignKey("dbo.Sitio", t => t.SitioID)
                .Index(t => t.SitioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdministradorSitio", "SitioID", "dbo.Sitio");
            DropForeignKey("dbo.Taxi", "SitioID", "dbo.Sitio");
            DropForeignKey("dbo.Chofer", "SitioID", "dbo.Sitio");
            DropForeignKey("dbo.Checador", "SitioID", "dbo.Sitio");
            DropIndex("dbo.Taxi", new[] { "SitioID" });
            DropIndex("dbo.Chofer", new[] { "SitioID" });
            DropIndex("dbo.Checador", new[] { "SitioID" });
            DropIndex("dbo.AdministradorSitio", new[] { "SitioID" });
            DropTable("dbo.Taxi");
            DropTable("dbo.Chofer");
            DropTable("dbo.Checador");
            DropTable("dbo.Sitio");
            DropTable("dbo.AdministradorSitio");
            DropTable("dbo.Administrador");
        }
    }
}
