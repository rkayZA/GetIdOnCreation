CREATE PROCEDURE [dbo].[sp_InsertSpecifications]
	@Id int output,
	@ProductId int,
	@Specification nvarchar(200)
	
AS
begin
	set nocount on;

	insert into dbo.ProductSpecification(ProductId, Specification)
	values (@ProductId, @Specification);

	SELECT CAST(SCOPE_IDENTITY() as int);
end