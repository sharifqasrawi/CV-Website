namespace My_Personal_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CVProfModels", "Position_Fr", c => c.String(nullable: false));
            AddColumn("dbo.CVProfModels", "Company_Fr", c => c.String(nullable: false));
            AddColumn("dbo.CVProfModels", "Desc_Fr", c => c.String());
            AddColumn("dbo.CVProfModels", "Country_Fr", c => c.String(nullable: false));
            AddColumn("dbo.CVProfModels", "City_Fr", c => c.String(nullable: false));
            AddColumn("dbo.ProfRefs", "RefRelation_Fr", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfRefs", "RefRelation_Fr");
            DropColumn("dbo.CVProfModels", "City_Fr");
            DropColumn("dbo.CVProfModels", "Country_Fr");
            DropColumn("dbo.CVProfModels", "Desc_Fr");
            DropColumn("dbo.CVProfModels", "Company_Fr");
            DropColumn("dbo.CVProfModels", "Position_Fr");
        }
    }
}
