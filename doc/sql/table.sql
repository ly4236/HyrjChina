CREATE TABLE [dbo].[Products] (
    [ProductID]   INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100)  NOT NULL,
    [Description] NVARCHAR (500)  NOT NULL,
    [Category]    NVARCHAR (50)   NOT NULL,
    [Price]       DECIMAL (16, 2) NOT NULL,
    [IsPulish]    BIT             NOT NULL,
    [CreateTime]  DATETIME2 (7)   DEFAULT (getdate()) NOT NULL,
    [IsDelete]    BIT             NOT NULL,
    [UpdateTime]  DATETIME2 (7)   NULL,
    [ProductGroupID] INT NULL, 
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

