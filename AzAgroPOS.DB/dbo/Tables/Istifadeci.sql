CREATE TABLE [dbo].[Istifadeci]
(
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Ad] NVARCHAR(100) NOT NULL,
    [Soyad] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL UNIQUE,
    [ParolHash] NVARCHAR(MAX) NOT NULL,
    [RolId] INT NULL,
    [TemaId] INT NULL,
    [Status] NVARCHAR(50) NOT NULL,
    CONSTRAINT [FK_Istifadeci_Rol] FOREIGN KEY ([RolId]) REFERENCES [dbo].[Rol]([Id]),
    CONSTRAINT [FK_Istifadeci_Tema] FOREIGN KEY ([TemaId]) REFERENCES [dbo].[Tema]([Id])
)