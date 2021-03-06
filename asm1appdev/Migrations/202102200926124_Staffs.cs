namespace asm1appdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Staffs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.String(nullable: false, maxLength: 128),
                        Age = c.String(),
                        DayOfBirthday = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.AspNetUsers", t => t.StaffId)
                .Index(t => t.StaffId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "StaffId", "dbo.AspNetUsers");
            DropIndex("dbo.Staffs", new[] { "StaffId" });
            DropTable("dbo.Staffs");
        }
    }
}
