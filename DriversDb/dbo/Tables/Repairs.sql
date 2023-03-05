CREATE TABLE [dbo].[Repairs] (
    [RepairID]    INT             IDENTITY (1, 1) NOT NULL,
    [RepairDate]  DATE            NOT NULL,
    [Description] NVARCHAR (200)  NULL,
    [Cost]        DECIMAL (10, 2) NOT NULL,
    [TruckID]     INT             NULL,
    [CreatedAt]   DATETIME        DEFAULT (getdate()) NULL,
    [UpdatedAt]   DATETIME        DEFAULT (getdate()) NULL,
    [DeletedAt]   DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([RepairID] ASC),
    FOREIGN KEY ([TruckID]) REFERENCES [dbo].[Trucks] ([TruckID])
);

