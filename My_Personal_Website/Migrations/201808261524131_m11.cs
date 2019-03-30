namespace My_Personal_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddressModels", "City_Fr", c => c.String());
            AddColumn("dbo.AddressModels", "Country_Fr", c => c.String());
            AddColumn("dbo.AddressModels", "AdditionalInfo_Fr", c => c.String());
            AddColumn("dbo.CVLangModels", "Language_Fr", c => c.String(nullable: false));
            AddColumn("dbo.CVSkillsModels", "SkillName_Fr", c => c.String(nullable: false));
            AddColumn("dbo.CVSkillsModels", "SkillType_Fr", c => c.String(nullable: false));
            AddColumn("dbo.CVSkillsModels", "Desc_Fr", c => c.String());
            AddColumn("dbo.CVTrainingModels", "CourseName_Fr", c => c.String(nullable: false));
            AddColumn("dbo.CVTrainingModels", "Source_Fr", c => c.String());
            DropTable("dbo.SiteStyles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SiteStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BgStyle = c.String(),
                        NavStyle = c.String(),
                        HeaderStyle = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.CVTrainingModels", "Source_Fr");
            DropColumn("dbo.CVTrainingModels", "CourseName_Fr");
            DropColumn("dbo.CVSkillsModels", "Desc_Fr");
            DropColumn("dbo.CVSkillsModels", "SkillType_Fr");
            DropColumn("dbo.CVSkillsModels", "SkillName_Fr");
            DropColumn("dbo.CVLangModels", "Language_Fr");
            DropColumn("dbo.AddressModels", "AdditionalInfo_Fr");
            DropColumn("dbo.AddressModels", "Country_Fr");
            DropColumn("dbo.AddressModels", "City_Fr");
        }
    }
}
