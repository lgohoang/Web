namespace Web.Miratech.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Web.Miratech.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Menu
            var Time = DateTime.Now;

            var Menu = new List<Models.MenuModels>
            {
               new Models.MenuModels { Name = "Home", Title="Trang chủ", ParentID = 0, isDropdown = false, Visible = true, ShowInView = true, CreateTime = Time},
               new Models.MenuModels { Name = "About", Title="Giới thiệu", ParentID = 0, isDropdown = false, Visible = true, ShowInView = true, CreateTime = Time},
               new Models.MenuModels { Name = "Product", Title="Sản phẩm", ParentID = 0, Visible = true, isDropdown = false, ShowInView = true, CreateTime = Time},
               new Models.MenuModels { Name = "Service", Title="Dịch vụ", ParentID = 0, Visible = true, isDropdown = false,ShowInView = true, CreateTime = Time},
               new Models.MenuModels { Name = "News", Title="Tin tức", ParentID = 0, Visible = true, isDropdown = false,ShowInView = true, CreateTime = Time},
            };

            Menu.ForEach(s => context.Menu.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //Category
            var Category = new List<Models.CategoryModels>
            {
                new Models.CategoryModels {Name = "Product", Title = "Sản phẩm", Enable = true, Visible = true },
                new Models.CategoryModels {Name = "Service", Title = "Dịch vụ", Enable = true, Visible = true },
                new Models.CategoryModels {Name = "News", Title = "Tin tức", Enable = true, Visible = true },
                new Models.CategoryModels {Name = "Significant", Title = "Đặc điểm nổi trội", Enable = true, Visible = true },
                new Models.CategoryModels {Name = "Carrers", Title = "Tuyển dụng", Enable = true, Visible = true },
            };
            Category.ForEach(s => context.Category.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //Article
            var Article = new List<Models.ArticleModels>
            {
                new Models.ArticleModels { Name = "Test", Title = "Kiểm tra", Content = "Kiểm tra, test" , CreateTime = Time},
            };
            Article.ForEach(s => context.Article.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //Role
            var Role = new List<Models.RoleModels>
            {
                new Models.RoleModels {Name = "Administrator", Role = "Administrator", Detail = "Quản trị viên", CreateTime = Time },
                new Models.RoleModels {Name = "Moderator", Role = "Moderator", Detail = "Người điều hành", CreateTime = Time },
                new Models.RoleModels {Name = "Poster", Role = "Poster", Detail = "Người đăng bài", CreateTime = Time },
            };
            Role.ForEach(s => context.Role.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //User
            var User = new List<Models.UserModels>
            {
                new Models.UserModels {RoleID = (from b in context.Role
                                                      where b.Name == "Administrator"
                                                      select b.ID).First(),
                Name = "Admin" ,
                FullName = "Admintrastor",
                Password = "F+5oa7jCZkaQZwUugvwYaTPGZQaly4UTRt3GAb0dyJL8v65BYsnI/8x7GDDGOeLvZ8i900D+oyhjkVxVvesa5Q==",
                PasswordSalt = "100000.LcHq1nR7Mzt9pyloYbUSav6RL+A7r5eyVZ/AMcHpkHDq/A==",
                CreateTime = Time},

                new Models.UserModels {RoleID = (from b in context.Role
                                                      where b.Name == "Administrator"
                                                      select b.ID).First(),
                Name = "huyennt" ,
                FullName = "Nguyễn Thị Huyền",
                Password = "F+5oa7jCZkaQZwUugvwYaTPGZQaly4UTRt3GAb0dyJL8v65BYsnI/8x7GDDGOeLvZ8i900D+oyhjkVxVvesa5Q==",
                PasswordSalt = "100000.LcHq1nR7Mzt9pyloYbUSav6RL+A7r5eyVZ/AMcHpkHDq/A==",
                CreateTime = Time},

                new Models.UserModels {RoleID = (from b in context.Role
                                                      where b.Name == "Poster"
                                                      select b.ID).First(),
                Name = "dunv" ,
                FullName = "Nguyễn Văn Du",
                Password = "F+5oa7jCZkaQZwUugvwYaTPGZQaly4UTRt3GAb0dyJL8v65BYsnI/8x7GDDGOeLvZ8i900D+oyhjkVxVvesa5Q==",
                PasswordSalt = "100000.LcHq1nR7Mzt9pyloYbUSav6RL+A7r5eyVZ/AMcHpkHDq/A==",
                CreateTime = Time},

                new Models.UserModels {RoleID = (from b in context.Role
                                                      where b.Name == "Administrator"
                                                      select b.ID).First(),
                Name = "hoangnv" ,
                FullName = "Nguyễn Văn Hoàng",
                Password = "F+5oa7jCZkaQZwUugvwYaTPGZQaly4UTRt3GAb0dyJL8v65BYsnI/8x7GDDGOeLvZ8i900D+oyhjkVxVvesa5Q==",
                PasswordSalt = "100000.LcHq1nR7Mzt9pyloYbUSav6RL+A7r5eyVZ/AMcHpkHDq/A==",
                CreateTime = Time},

            };
            User.ForEach(s => context.User.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
