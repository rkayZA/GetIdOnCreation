CREATE PROCEDURE [dbo].[sp_GetAllProducts]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, ProductName, ProductDescription
	FROM dbo.Product;
	
END