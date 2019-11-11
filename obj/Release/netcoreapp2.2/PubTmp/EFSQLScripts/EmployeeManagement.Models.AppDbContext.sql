IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191031214357_PaymentCollection')
BEGIN
    CREATE TABLE [Products] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [Price] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [PhotoPath] nvarchar(max) NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191031214357_PaymentCollection')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'PhotoPath', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    INSERT INTO [Products] ([Id], [Description], [Name], [PhotoPath], [Price])
    VALUES (N'9cd853ac-a006-4825-acd5-021f43ab418c', N'Best laptop bag ever', N'Laptop Bag', NULL, 50000);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'PhotoPath', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191031214357_PaymentCollection')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'PhotoPath', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    INSERT INTO [Products] ([Id], [Description], [Name], [PhotoPath], [Price])
    VALUES (N'7edb9eb1-aacf-4fe8-81a2-8ca80b6de674', N'Water bottle for life', N'Water Bottle', NULL, 15000);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'PhotoPath', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191031214357_PaymentCollection')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191031214357_PaymentCollection', N'2.2.6-servicing-10079');
END;

GO

