namespace Giangbb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2ecabdca-dbb3-44e9-b8f5-66fcd3a155c4', N'admin@admin.com', 0, N'AHgPUhiNFvSnlzA81JQzdq178bm1OLNn7NJKAc/x6WCmwifzeOKKyHwzIHfslMo7TQ==', N'1a44fbfb-efb3-446a-b09e-c4bef876247b', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a95ad2ce-2ece-49b9-8cf1-ee7d5b9c639e', N'guest@gmail.com', 0, N'AAexwcc3b1O3MoT1amI5bmSUN7RMkQzhd4myur4vmjkDHHTzlyISzXrRZM9yjIXB4g==', N'1f21beb5-46a0-4b4e-8d5d-87af5c6f3a47', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7a5b952f-47c4-4c67-b8b7-33a03c6fe2a8', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ecabdca-dbb3-44e9-b8f5-66fcd3a155c4', N'7a5b952f-47c4-4c67-b8b7-33a03c6fe2a8')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
