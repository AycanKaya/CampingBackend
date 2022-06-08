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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220517145452_InitialMigration')
BEGIN
    CREATE TABLE [Customers] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220517145452_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220517145452_InitialMigration', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519112305_Owner')
BEGIN
    ALTER TABLE [Customers] DROP CONSTRAINT [PK_Customers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519112305_Owner')
BEGIN
    EXEC sp_rename N'[Customers]', N'Customer';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519112305_Owner')
BEGIN
    ALTER TABLE [Customer] ADD CONSTRAINT [PK_Customer] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519112305_Owner')
BEGIN
    CREATE TABLE [Owner] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Owner] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519112305_Owner')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220519112305_Owner', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519165937_VacationSpot')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519165937_VacationSpot')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220519165937_VacationSpot', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220522124600_Campsite')
BEGIN
    CREATE TABLE [Bill] (
        [Id] int NOT NULL IDENTITY,
        [OrderId] int NOT NULL,
        CONSTRAINT [PK_Bill] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220522124600_Campsite')
BEGIN
    CREATE TABLE [Campsite] (
        [VacationSpotID] int NOT NULL IDENTITY,
        [OwnerID] int NOT NULL,
        [AdultPrice] int NOT NULL,
        [ChildPrice] int NOT NULL,
        [SeasonStartDate] datetime2 NOT NULL,
        [SeasonCloseDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Campsite] PRIMARY KEY ([VacationSpotID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220522124600_Campsite')
BEGIN
    CREATE TABLE [Card] (
        [CardNo] nvarchar(450) NOT NULL,
        [ExprationDate] datetime2 NOT NULL,
        [CardType] int NOT NULL,
        CONSTRAINT [PK_Card] PRIMARY KEY ([CardNo])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220522124600_Campsite')
BEGIN
    CREATE TABLE [Order] (
        [Id] int NOT NULL IDENTITY,
        [CustomerId] int NOT NULL,
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220522124600_Campsite')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220522124600_Campsite', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220524100014_Payment')
BEGIN
    CREATE TABLE [Payment] (
        [Id] int NOT NULL IDENTITY,
        [OrderId] int NOT NULL,
        [TotalPrice] int NOT NULL,
        CONSTRAINT [PK_Payment] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220524100014_Payment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220524100014_Payment', N'6.0.5');
END;
GO

COMMIT;
GO

