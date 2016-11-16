CREATE TABLE [dbo].[Product] (
    [Id]          BIGINT           IDENTITY (1,1) NOT NULL,
    [RefId]       UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (50)    NULL,
    [Description] NVARCHAR (250)   NULL,
    [Price]       DECIMAL (18)     NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);

