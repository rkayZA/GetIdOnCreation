CREATE TABLE [dbo].[ProductSpecification]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [Specification] NVARCHAR(200) NOT NULL
)
