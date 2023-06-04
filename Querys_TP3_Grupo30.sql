create PROCEDURE storedArticulo
   @IdArticulo INT
AS
BEGIN
   Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, Precio, A.IdMarca, A.IdCategoria
	from ARTICULOS A
	left join MARCAS M on A.IdMarca = M.Id
	left join CATEGORIAS C on A.IdCategoria = C.Id
	where A.Id = @IdArticulo
END



CREATE PROCEDURE storedImg
   @IdArticulo INT
AS
BEGIN
   SELECT ID, IDARTICULO, IMAGENURL
   FROM IMAGENES
   WHERE IDARTICULO = @IdArticulo;
END



CREATE procedure storedListar
as
begin
	Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, Precio, A.IdMarca, A.IdCategoria
	From ARTICULOS A, CATEGORIAS C, MARCAS M
	Where C.Id = A.IdCategoria And M.Id = A.IdMarca
end


CREATE PROCEDURE storedFiltro
   @filtro varchar(100)
AS
BEGIN
   SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio, A.IdMarca, A.IdCategoria
   FROM ARTICULOS A, CATEGORIAS C, MARCAS M
   WHERE C.Id = A.IdCategoria AND M.Id = A.IdMarca
   GROUP BY A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion, C.Descripcion, Precio, A.IdMarca, A.IdCategoria
   HAVING Codigo LIKE '%' + @filtro + '%' OR Nombre LIKE '%' + @filtro + '%' OR A.Descripcion LIKE '%' + @filtro + '%' OR M.Descripcion LIKE '%' + @filtro + '%' OR C.Descripcion LIKE '%' + @filtro + '%'
END