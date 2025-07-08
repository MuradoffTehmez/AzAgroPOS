CREATE TABLE [dbo].[RolIcazesi]
(
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [RolId] INT NOT NULL,
    [Modul] NVARCHAR(100) NOT NULL,
    [Emeliyyat] NVARCHAR(100) NOT NULL,
    [IcazeVerilib] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_RolIcazesi_Rol] FOREIGN KEY ([RolId]) REFERENCES [dbo].[Rol]([Id])
)