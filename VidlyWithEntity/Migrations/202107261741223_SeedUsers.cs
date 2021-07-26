namespace VidlyWithEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'65e6c264-8381-48a6-8c64-1689248413bf', N'rksujon126706@gmail.com', 0, N'AJpHcXLkSwi+9ke6CbpmuAKw88qKyUZI7tUtfYp750NIvUqEKK24C06Emm8+IzeoiQ==', N'9837b112-2b59-4f4d-aadc-fd287b9e851c', NULL, 0, 0, NULL, 1, 0, N'rksujon126706@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8530bde3-bc36-4410-88d6-06d9e61aeece', N'admin@vidly.com', 0, N'ANCqtD3bm4bdgQQX3wGTDZsboQE3cI/ECU0LOYDhVf9iBe5NzX/qDZpz/aOPnxG/6Q==', N'fbc9ab6d-3f86-499b-bdf3-4a68f66eebfd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c9a2c921-d8f4-408c-b477-7d741ed7bf18', N'guest@vidly.com', 0, N'AEOkhCXFm9nS1tpKOsdFSZFMSdwllNSpetrtWUmjd+h0gcLxdw6bC/ygZ649uW+TRQ==', N'88623c8c-7056-4a39-9500-3364be9d222e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'185c05dc-4852-4bf1-89de-a76167d36eda', N'CanManageMovie')
                    
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8530bde3-bc36-4410-88d6-06d9e61aeece', N'185c05dc-4852-4bf1-89de-a76167d36eda')

");
        }
        
        public override void Down()
        {
        }
    }
}
