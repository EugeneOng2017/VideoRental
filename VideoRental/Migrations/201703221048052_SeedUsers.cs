namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f2b51854-1793-4b61-8e32-4c36de475521', N'admin@email.com', 0, N'AKYQwsOqWUwQj622AmGDCW/VvDoAkTeafZJNr8FoVeFw8RQuYo0blsF15Xfx4S8gWw==', N'd5fea2c3-9a1d-40e9-a2b3-9da043157db3', NULL, 0, 0, NULL, 1, 0, N'admin@email.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fc389973-21a1-4df7-ac03-400425f147e3', N'guest@email.com', 0, N'ABrUwEEprL7xmyPvB0ykKqAeo4stm9q6zuV7qebjebhTnf4yXmOn+p5kJ8G94gHTHA==', N'803969e5-be30-4a42-8a0f-5d1ac21607bc', NULL, 0, 0, NULL, 1, 0, N'guest@email.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'912d329a-41ee-4f0b-a974-7e3b48c8db05', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f2b51854-1793-4b61-8e32-4c36de475521', N'912d329a-41ee-4f0b-a974-7e3b48c8db05')
");
        }
        
        public override void Down()
        {
        }
    }
}
