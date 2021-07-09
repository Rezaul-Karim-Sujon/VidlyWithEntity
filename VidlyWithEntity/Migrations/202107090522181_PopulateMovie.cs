namespace VidlyWithEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('Hangover',5,'2016-5-4','2009-11-6',5)");
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('Die Hard',1,'2016-5-4','1988-7-12',3)");
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('The Terminator',1,'2016-5-4','2009-10-26',6)");
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('Toy Story 4',3,'2016-5-4','2019-6-11',4)");
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('Titanic',4,'2016-5-4','1997-11-18',1)");
        }
        
        public override void Down()
        {
        }
    }
}
