CREATE TABLE [dbo].[Expenses] (
    [ExpensesID]      INT             IDENTITY (1, 1) NOT NULL,
    [DriverID]        INT             NOT NULL,
    [TruckID]         INT             NOT NULL,
    [DriverPayment]   DECIMAL (10, 2) NOT NULL,
    [FuelCost]        DECIMAL (10, 2) NOT NULL,
    [MaintenanceCost] DECIMAL (10, 2) NOT NULL,
    [Category]        VARCHAR (255)   NOT NULL,
    [Date]            DATE            NOT NULL,
    [Note]            TEXT            NULL,
    [CreatedAt]       DATETIME        DEFAULT (getdate()) NULL,
    [UpdatedAt]       DATETIME        DEFAULT (getdate()) NULL,
    [DeletedAt]       DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([ExpensesID] ASC),
    FOREIGN KEY ([DriverID]) REFERENCES [dbo].[Drivers] ([DriverID]),
    FOREIGN KEY ([TruckID]) REFERENCES [dbo].[Trucks] ([TruckID])
);

