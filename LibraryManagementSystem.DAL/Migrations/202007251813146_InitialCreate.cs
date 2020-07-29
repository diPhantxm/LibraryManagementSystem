namespace LibraryManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        PicPath = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        Language = c.String(),
                        Category = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Pages = c.Short(nullable: false),
                        Price = c.Short(nullable: false),
                        Rating = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookDimensions", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.BookDimensions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Length = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Reader_Id = c.Int(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Book_Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Readers", t => t.Reader_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Reader_Id);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Salt = c.Binary(),
                        Iterations = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Reader_Id", "dbo.Readers");
            DropForeignKey("dbo.Rents", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Id", "dbo.BookDimensions");
            DropIndex("dbo.Rents", new[] { "Reader_Id" });
            DropIndex("dbo.Rents", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "Id" });
            DropTable("dbo.Readers");
            DropTable("dbo.Rents");
            DropTable("dbo.BookDimensions");
            DropTable("dbo.Books");
        }
    }
}
