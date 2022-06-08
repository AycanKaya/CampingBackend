IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [Bill] (
        [Id] int NOT NULL IDENTITY,
        [OrderId] int NOT NULL,
        CONSTRAINT [PK_Bill] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [Campsite] (
        [VacationSpotID] int NOT NULL IDENTITY,
        [OwnerID] nvarchar(max) NOT NULL,
        [AdultPrice] int NOT NULL,
        [ChildPrice] int NOT NULL,
        [SeasonStartDate] datetime2 NOT NULL,
        [SeasonCloseDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Campsite] PRIMARY KEY ([VacationSpotID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [Card] (
        [CardNo] nvarchar(450) NOT NULL,
        [ExprationDate] datetime2 NOT NULL,
        [CardType] int NOT NULL,
        [UserId] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Card] PRIMARY KEY ([CardNo])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [Order] (
        [Id] int NOT NULL IDENTITY,
        [CustomerId] nvarchar(max) NOT NULL,
        [PlaceId] int NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NOT NULL,
        [NumOfAdult] int NOT NULL,
        [NumOfChilder] int NOT NULL,
        [isPaid] bit NOT NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [Payment] (
        [Id] int NOT NULL IDENTITY,
        [OrderId] int NOT NULL,
        [TotalPrice] int NOT NULL,
        CONSTRAINT [PK_Payment] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [VacationSpot] (
        [Id] int NOT NULL IDENTITY,
        [Address] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [Capacity] int NOT NULL,
        [isValid] bit NOT NULL,
        CONSTRAINT [PK_VacationSpot] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE TABLE [RefreshToken] (
        [Id] int NOT NULL IDENTITY,
        [Token] nvarchar(max) NOT NULL,
        [Expires] datetime2 NOT NULL,
        [Created] datetime2 NOT NULL,
        [CreatedByIp] nvarchar(max) NOT NULL,
        [Revoked] datetime2 NULL,
        [RevokedByIp] nvarchar(max) NOT NULL,
        [ReplacedByToken] nvarchar(max) NOT NULL,
        [ApplicationUserId] nvarchar(450) NULL,
        CONSTRAINT [PK_RefreshToken] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RefreshToken_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    CREATE INDEX [IX_RefreshToken_ApplicationUserId] ON [RefreshToken] ([ApplicationUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220529081110_initialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220529081110_initialMigration', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    ALTER TABLE [Campsite] ADD [Description] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    ALTER TABLE [Campsite] ADD [HolidayDestinationID] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    ALTER TABLE [Campsite] ADD [Name] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    ALTER TABLE [Campsite] ADD [Rate] real NOT NULL DEFAULT CAST(0 AS real);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    ALTER TABLE [Campsite] ADD [lat] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    ALTER TABLE [Campsite] ADD [lng] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    CREATE TABLE [Comment] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [UserID] int NOT NULL,
        [CampsiteID] int NOT NULL,
        CONSTRAINT [PK_Comment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Comment_Campsite_CampsiteID] FOREIGN KEY ([CampsiteID]) REFERENCES [Campsite] ([VacationSpotID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    CREATE TABLE [HolidayDestination] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [CityName] nvarchar(max) NOT NULL,
        [Information] nvarchar(max) NOT NULL,
        [FotoUri] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_HolidayDestination] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    CREATE TABLE [Link] (
        [Id] int NOT NULL IDENTITY,
        [Url] nvarchar(max) NOT NULL,
        [CampsiteVacationSpotID] int NULL,
        CONSTRAINT [PK_Link] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Link_Campsite_CampsiteVacationSpotID] FOREIGN KEY ([CampsiteVacationSpotID]) REFERENCES [Campsite] ([VacationSpotID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    CREATE INDEX [IX_Comment_CampsiteID] ON [Comment] ([CampsiteID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    CREATE INDEX [IX_Link_CampsiteVacationSpotID] ON [Link] ([CampsiteVacationSpotID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220531085325_addedNewTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220531085325_addedNewTables', N'6.0.5');
END;
GO

COMMIT;
GO

