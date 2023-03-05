CREATE TABLE [dbo].[Companies] (
    [CompanyID]     INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName]   NVARCHAR (100) NOT NULL,
    [Address]       NVARCHAR (100) NULL,
    [Phone]         NVARCHAR (40)  NULL,
    [Email]         NVARCHAR (50)  NULL,
    [ContactPerson] NVARCHAR (100) NULL,
    [ContactPhone]  NVARCHAR (20)  NULL,
    [ContactEmail]  NVARCHAR (50)  NULL,
    [CreatedAt]     DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAt]     DATETIME       DEFAULT (getdate()) NULL,
    [DeletedAt]     DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([CompanyID] ASC)
);

