namespace Spellbook.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration524 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Spellbook_SpellListId", c => c.Int());
            CreateIndex("dbo.Characters", "Spellbook_SpellListId");
            AddForeignKey("dbo.Characters", "Spellbook_SpellListId", "dbo.SpellLists", "SpellListId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "Spellbook_SpellListId", "dbo.SpellLists");
            DropIndex("dbo.Characters", new[] { "Spellbook_SpellListId" });
            DropColumn("dbo.Characters", "Spellbook_SpellListId");
        }
    }
}
