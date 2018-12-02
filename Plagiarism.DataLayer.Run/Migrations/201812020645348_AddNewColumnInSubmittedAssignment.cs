namespace Plagiarism.DataLayer.Run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumnInSubmittedAssignment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubmittedAssignments", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubmittedAssignments", "IsChecked");
        }
    }
}
