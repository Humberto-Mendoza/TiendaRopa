CREATE PROCEDURE sp_InsertarProducto
 @Nombre VARCHAR(150),
 @Precio DECIMAL(10,2),
 @Stock INT,
 @Descuento DECIMAL(5,2),
 @Imagen VARCHAR(255),
 @IdCategoria INT
AS
BEGIN
 INSERT INTO Productos
 VALUES (@Nombre,@Precio,@Stock,@Descuento,@Imagen,@IdCategoria,1)
END

----------------------------------------------------------
GO
CREATE PROCEDURE sp_ListarProductos
AS
BEGIN
 SELECT * FROM Productos WHERE Estado = 1
END

GO
-- aplicar descuento en el stock
CREATE TRIGGER trg_DescontarStock
ON DetalleFactura
AFTER INSERT
AS
BEGIN
 UPDATE Productos
 SET Stock = Stock - i.Cantidad
 FROM Productos p
 INNER JOIN inserted i ON p.IdProducto = i.IdProducto
END

GO
CREATE PROCEDURE sp_Login
 @Usuario VARCHAR(50),
 @Clave VARCHAR(200)
AS
BEGIN
 SELECT u.IdUsuario, u.Usuario, r.Nombre AS Rol
 FROM Usuarios u
 INNER JOIN Roles r ON u.IdRol = r.IdRol
 WHERE u.Usuario = @Usuario AND u.Clave = @Clave
END


INSERT INTO Usuarios VALUES ('admin','123',1);
INSERT INTO Usuarios VALUES ('vendedor','123',2);



----Insertar factura
GO
CREATE PROCEDURE sp_InsertarFactura
 @IdCliente INT,
 @IdUsuario INT,
 @Total DECIMAL(10,2)
AS
BEGIN
 INSERT INTO Facturas
 VALUES (GETDATE(), @IdCliente, @IdUsuario, @Total)

 SELECT SCOPE_IDENTITY() AS IdFactura
END



--Insertar detalle de factura
GO
CREATE PROCEDURE sp_InsertarDetalleFactura
 @IdFactura INT,
 @IdProducto INT,
 @Cantidad INT,
 @Precio DECIMAL(10,2),
 @Descuento DECIMAL(5,2)
AS
BEGIN
 DECLARE @SubTotal DECIMAL(10,2)

 SET @SubTotal = (@Cantidad * @Precio) - @Descuento

 INSERT INTO DetalleFactura
 VALUES (@IdFactura, @IdProducto, @Cantidad, @Precio, @Descuento, @SubTotal)
END



--Lista de productos para la venta
GO
CREATE PROCEDURE sp_ListarProductosVenta
AS
BEGIN
 SELECT IdProducto, Nombre, Precio, Stock
 FROM Productos
 WHERE Estado = 1 AND Stock > 0
END



-------------------------

-- Procedimientos para reporetes
GO
CREATE PROCEDURE sp_VentasPorFecha
 @FechaInicio DATE,
 @FechaFin DATE
AS
BEGIN
 SELECT f.IdFactura, f.Fecha,
        c.Nombre1 + ' ' + c.Apellido1 AS Cliente,
        f.Total
 FROM Facturas f
 INNER JOIN Clientes c ON f.IdCliente = c.IdCliente
 WHERE CAST(f.Fecha AS DATE) BETWEEN @FechaInicio AND @FechaFin
END


-- ventas por cliente
GO
CREATE PROCEDURE sp_VentasPorCliente
 @IdCliente INT
AS
BEGIN
 SELECT f.IdFactura, f.Fecha, f.Total
 FROM Facturas f
 WHERE f.IdCliente = @IdCliente
END



-- producto mas vendido
GO
CREATE PROCEDURE sp_ProductosMasVendidos
AS
BEGIN
 SELECT p.Nombre,
        SUM(d.Cantidad) AS TotalVendido
 FROM DetalleFactura d
 INNER JOIN Productos p ON d.IdProducto = p.IdProducto
 GROUP BY p.Nombre
 ORDER BY TotalVendido DESC
END


-- para rel registro FEL
GO
CREATE PROCEDURE sp_RegistrarFEL
 @IdFactura INT,
 @UUID VARCHAR(100),
 @Serie VARCHAR(20),
 @Numero VARCHAR(20),
 @Estado VARCHAR(50),
 @XML VARCHAR(MAX)
AS
BEGIN
 INSERT INTO FelDocumentos
 VALUES (@IdFactura,@UUID,@Serie,@Numero,GETDATE(),@Estado,@XML)
END


