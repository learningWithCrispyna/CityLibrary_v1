namespace CityLibrary.MVC.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AuthorId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("Books", new[] { "GenreId" });
            DropIndex("Books", new[] { "AuthorId" });
            DropForeignKey("Books", "GenreId", "Genres");
            DropForeignKey("Books", "AuthorId", "Authors");
            DropTable("Genres");
            DropTable("Books");
            DropTable("Authors");
        }
    }
}
