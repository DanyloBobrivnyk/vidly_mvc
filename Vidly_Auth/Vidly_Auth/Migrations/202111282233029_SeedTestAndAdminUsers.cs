namespace Vidly_Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTestAndAdminUsers : DbMigration
    {
        public override void Up()
        {
            //Users
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4b68ede3-12ef-4a4e-9b92-c0bcd3932662', N'test@gmail.com', 0, N'AGFiEXpuYeSRsWBFMNaOTIPdeKtU1zSTU29PH9T1O2ZJWprW20duwOxr+R/K64QAzQ==', N'c28d92dd-cae7-4d9a-9d53-c8ac23a1786b', NULL, 0, 0, NULL, 1, 0, N'test@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8a671c79-4668-47fa-b077-52d3595db1fc', N'admin@gmail.com', 0, N'ALz4w9Y/7d3D5YPWsV+0avZqUuZX0+XTsJCXJ4gJdjtXWSw1G5fNfZE5hMbXjcUiNA==', N'aad1aeb6-1b19-4d72-9cf7-7a08948487a4', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')");
            
            //StoreManager Role
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'eddd1d0e-c237-47ec-9756-2e7a47fd518a', N'CanManageMovies')");
            
            //Role asignment to the user.
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8a671c79-4668-47fa-b077-52d3595db1fc', N'eddd1d0e-c237-47ec-9756-2e7a47fd518a')");
        }
        
        public override void Down()
        {
        }
    }
}
