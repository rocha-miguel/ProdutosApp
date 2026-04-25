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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260418195750_Initial'
)
BEGIN
    CREATE TABLE [PRODUTOS] (
        [ID] uniqueidentifier NOT NULL,
        [NOME] nvarchar(150) NOT NULL,
        [PRECO] DECIMAL(10,2) NOT NULL,
        [QUANTIDADE] int NOT NULL,
        [DATAHORACADASTRO] datetime2 NOT NULL,
        [CATEGORIA] int NOT NULL,
        [STATUS] int NOT NULL,
        CONSTRAINT [PK_PRODUTOS] PRIMARY KEY ([ID])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260418195750_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260418195750_Initial', N'10.0.6');
END;

COMMIT;
GO

