namespace Web.Miratech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        isDropdown = c.Boolean(nullable: false),
                        ParentID = c.Int(nullable: false),
                        Order = c.Int(),
                        Visible = c.Boolean(nullable: false),
                        ShowInView = c.Boolean(nullable: false),
                        Target = c.String(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Icon = c.String(),
                        Order = c.Int(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ArticleModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Name = c.String(),
                        Title = c.String(),
                        Describe = c.String(),
                        Content = c.String(),
                        Image = c.String(),
                        Visible = c.Boolean(nullable: false),
                        Enable = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(),
                        LastEditUser = c.Int(),
                        LastEditTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SlideModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Name = c.String(),
                        Title = c.String(),
                        Describe = c.String(),
                        Content = c.String(),
                        Background = c.String(),
                        Image = c.String(),
                        Video = c.String(),
                        Visible = c.Boolean(nullable: false),
                        Enable = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(),
                        LastEditUser = c.Int(),
                        LastEditTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        Name = c.String(),
                        Password = c.String(),
                        PasswordSalt = c.String(),
                        FullName = c.String(),
                        CreateTime = c.DateTime(),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.String(),
                        Detail = c.String(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ClientModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Infomation = c.String(),
                        Order = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LogModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogModels");
            DropTable("dbo.ClientModels");
            DropTable("dbo.RoleModels");
            DropTable("dbo.UserModels");
            DropTable("dbo.SlideModels");
            DropTable("dbo.ArticleModels");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.MenuModels");
        }
    }
}
