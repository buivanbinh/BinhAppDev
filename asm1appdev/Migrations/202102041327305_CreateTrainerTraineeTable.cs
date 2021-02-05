namespace asm1appdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrainerTraineeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        TraineeId = c.String(nullable: false, maxLength: 128),
                        Age = c.String(),
                        DayOfBirth = c.String(),
                        Education = c.String(),
                        ProgramingLanguage = c.String(),
                        ToeicScore = c.String(),
                        Experience = c.Int(nullable: false),
                        Location = c.String(),
                        CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.TraineeId)
                .ForeignKey("dbo.AspNetUsers", t => t.TraineeId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.TraineeId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerId = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        WorkingPlace = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.TrainerId)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.TrainerId)
                .Index(t => t.CourseId);
            
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainees", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainees", "TraineeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Trainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "TrainerId", "dbo.AspNetUsers");
            DropIndex("dbo.Trainers", new[] { "CourseId" });
            DropIndex("dbo.Trainers", new[] { "TrainerId" });
            DropIndex("dbo.Trainees", new[] { "CourseId" });
            DropIndex("dbo.Trainees", new[] { "TraineeId" });
            DropColumn("dbo.AspNetUsers", "FullName");
            DropTable("dbo.Trainers");
            DropTable("dbo.Trainees");
        }
    }
}
