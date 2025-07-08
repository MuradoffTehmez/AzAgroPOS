CREATE TABLE [dbo].[AuditLog]
(
    [Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [IstifadeciId] INT NULL,
    [Emeliyyat] NVARCHAR(255) NOT NULL,
    [Detal] NVARCHAR(MAX) NULL,
    [IP] NVARCHAR(50) NULL,
    [Tarix] DATETIME NULL DEFAULT GETDATE(),
    CONSTRAINT [FK_AuditLog_Istifadeci] FOREIGN KEY ([IstifadeciId]) REFERENCES [dbo].[Istifadeci]([Id])
)