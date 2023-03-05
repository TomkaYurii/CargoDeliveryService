CREATE TABLE [dbo].[Inspections] (
    [InspectionID]   INT            IDENTITY (1, 1) NOT NULL,
    [InspectionDate] DATE           NOT NULL,
    [Description]    NVARCHAR (500) NULL,
    [Result]         BIT            NOT NULL,
    [TruckID]        INT            NULL,
    [CreatedAt]      DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAt]      DATETIME       DEFAULT (getdate()) NULL,
    [DeletedAt]      DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([InspectionID] ASC),
    FOREIGN KEY ([TruckID]) REFERENCES [dbo].[Trucks] ([TruckID])
);

