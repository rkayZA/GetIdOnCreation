CREATE PROCEDURE [dbo].[sp_ProductAdd]
	@ProductName nvarchar(100),
	@ProductDescription nvarchar(MAX)
	
AS
begin
	set nocount on;

	insert into dbo.Product(ProductName, ProductDescription)
	values (@ProductName, @ProductDescription);

end