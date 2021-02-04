CREATE PROCEDURE [dbo].[sp_DeleteProduct]
	@ProductId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.ProductSpecification where ProductId = @ProductId;
	DELETE FROM dbo.Product where Id = @ProductId;
	
END