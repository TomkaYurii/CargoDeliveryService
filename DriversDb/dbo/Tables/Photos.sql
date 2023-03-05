CREATE TABLE [dbo].[Photos] (
    [PhotoID]     INT             IDENTITY (1, 1) NOT NULL,
    [PhotoData]   VARBINARY (MAX) NOT NULL,
    [ContentType] NVARCHAR (50)   NOT NULL,
    [FileName]    NVARCHAR (255)  NOT NULL,
    [FileSize]    INT             NOT NULL,
    [CreatedAt]   DATETIME        DEFAULT (getdate()) NULL,
    [UpdatedAt]   DATETIME        DEFAULT (getdate()) NULL,
    [DeletedAt]   DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([PhotoID] ASC)
);

