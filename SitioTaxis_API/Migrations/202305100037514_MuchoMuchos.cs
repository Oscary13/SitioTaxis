namespace SitioTaxis_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MuchoMuchos : DbMigration
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
                        Nombre = c.String(nullable: false),
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
                "dbo.TaxiChofer",
                c => new
                    {
                        TaxiChoferID = c.Int(nullable: false, identity: true),
                        TaxiID = c.Int(nullable: false),
                        ChoferID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaxiChoferID)
                .ForeignKey("dbo.Chofer", t => t.ChoferID, cascadeDelete: true)
                .ForeignKey("dbo.Taxi", t => t.TaxiID, cascadeDelete: true)
                .Index(t => t.TaxiID)
                .Index(t => t.ChoferID);
            
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
            
            CreateTable(
                "dbo.Viaje",
                c => new
                    {
                        ViajeID = c.Int(nullable: false, identity: true),
                        Fecha = c.String(nullable: false),
                        HoraInicio = c.String(nullable: false),
                        UbicacionInicio = c.String(nullable: false),
                        HoraFinal = c.String(nullable: false),
                        UbicacionFinal = c.String(nullable: false),
                        TiempoTotal = c.String(nullable: false),
                        Estatus = c.String(nullable: false),
                        PasajeroID = c.Int(),
                        TaxiChoferID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ViajeID)
                .ForeignKey("dbo.Pasajero", t => t.PasajeroID)
                .ForeignKey("dbo.TaxiChofer", t => t.TaxiChoferID, cascadeDelete: true)
                .Index(t => t.PasajeroID)
                .Index(t => t.TaxiChoferID);
            
            CreateTable(
                "dbo.Pasajero",
                c => new
                    {
                        PasajeroID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        NumeroTelefono = c.String(nullable: false),
                        CorreoElectronico = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PasajeroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdministradorSitio", "SitioID", "dbo.Sitio");
            DropForeignKey("dbo.Viaje", "TaxiChoferID", "dbo.TaxiChofer");
            DropForeignKey("dbo.Viaje", "PasajeroID", "dbo.Pasajero");
            DropForeignKey("dbo.TaxiChofer", "TaxiID", "dbo.Taxi");
            DropForeignKey("dbo.Taxi", "SitioID", "dbo.Sitio");
            DropForeignKey("dbo.TaxiChofer", "ChoferID", "dbo.Chofer");
            DropForeignKey("dbo.Chofer", "SitioID", "dbo.Sitio");
            DropForeignKey("dbo.Checador", "SitioID", "dbo.Sitio");
            DropIndex("dbo.Viaje", new[] { "TaxiChoferID" });
            DropIndex("dbo.Viaje", new[] { "PasajeroID" });
            DropIndex("dbo.Taxi", new[] { "SitioID" });
            DropIndex("dbo.TaxiChofer", new[] { "ChoferID" });
            DropIndex("dbo.TaxiChofer", new[] { "TaxiID" });
            DropIndex("dbo.Chofer", new[] { "SitioID" });
            DropIndex("dbo.Checador", new[] { "SitioID" });
            DropIndex("dbo.AdministradorSitio", new[] { "SitioID" });
            DropTable("dbo.Pasajero");
            DropTable("dbo.Viaje");
            DropTable("dbo.Taxi");
            DropTable("dbo.TaxiChofer");
            DropTable("dbo.Chofer");
            DropTable("dbo.Checador");
            DropTable("dbo.Sitio");
            DropTable("dbo.AdministradorSitio");
            DropTable("dbo.Administrador");
        }
    }
}
