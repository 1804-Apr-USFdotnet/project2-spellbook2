namespace Spellbook.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Spells",
                c => new
                    {
                        SpellId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        School = c.String(),
                        Level = c.Int(nullable: false),
                        Ritual = c.Boolean(nullable: false),
                        CastingTime = c.String(),
                        Source = c.String(),
                        Range = c.String(),
                        Classes = c.String(),
                        Components = c.String(),
                        Duration = c.String(),
                        AtHigherLevel = c.String(),
                        Concentration = c.Boolean(nullable: false),
                        Slug = c.String(),
                        Page = c.Int(),
                        Description = c.String(),
                        ClassesAsInt = c.Int(),
                    })
                .PrimaryKey(t => t.SpellId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Spells");
        }
    }
}
