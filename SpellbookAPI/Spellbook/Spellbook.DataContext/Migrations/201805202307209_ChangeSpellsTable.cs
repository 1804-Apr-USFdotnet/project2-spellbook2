namespace Spellbook.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSpellsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId);
            
            CreateTable(
                "dbo.SpellLists",
                c => new
                    {
                        SpellListId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SpellListId);
            
            CreateTable(
                "dbo.SpellListSpells",
                c => new
                    {
                        SpellListSpellsId = c.Int(nullable: false, identity: true),
                        SpellListId = c.Int(nullable: false),
                        SpellId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpellListSpellsId)
                .ForeignKey("dbo.Spells", t => t.SpellId, cascadeDelete: true)
                .ForeignKey("dbo.SpellLists", t => t.SpellListId, cascadeDelete: true)
                .Index(t => t.SpellListId)
                .Index(t => t.SpellId);
            
            AlterColumn("dbo.Spells", "ClassesAsInt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpellListSpells", "SpellListId", "dbo.SpellLists");
            DropForeignKey("dbo.SpellListSpells", "SpellId", "dbo.Spells");
            DropIndex("dbo.SpellListSpells", new[] { "SpellId" });
            DropIndex("dbo.SpellListSpells", new[] { "SpellListId" });
            AlterColumn("dbo.Spells", "ClassesAsInt", c => c.Int());
            DropTable("dbo.SpellListSpells");
            DropTable("dbo.SpellLists");
            DropTable("dbo.Characters");
        }
    }
}
