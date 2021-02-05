CREATE PROCEDURE [dbo].[sp_ProductAdd]
	@Id int output,
	@ProductName nvarchar(100),
	@ProductDescription nvarchar(MAX)
	
AS
begin
	set nocount on;

	insert into dbo.Product(ProductName, ProductDescription)
	values (@ProductName, @ProductDescription);

	--select @Id = SCOPE_IDENTITY();
	SELECT CAST(SCOPE_IDENTITY() as int);
end