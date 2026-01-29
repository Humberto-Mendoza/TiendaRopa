CREATE DATABASE TiendaRopa;
GO
USE TiendaRopa;

CREATE TABLE Roles(
 IdRol INT IDENTITY PRIMARY KEY,
 Nombre VARCHAR(50)
);

INSERT INTO Roles VALUES ('Administrador'),('Vendedor');

CREATE TABLE Usuarios(
 IdUsuario INT IDENTITY PRIMARY KEY,
 Usuario VARCHAR(50),
 Clave VARCHAR(200),
 IdRol INT,
 FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);

CREATE TABLE Categorias(
 IdCategoria INT IDENTITY PRIMARY KEY,
 Nombre VARCHAR(100)
);

CREATE TABLE Productos(
 IdProducto INT IDENTITY PRIMARY KEY,
 Nombre VARCHAR(150),
 Precio DECIMAL(10,2),
 Stock INT,
 DescuentoInventario DECIMAL(5,2),
 Imagen VARCHAR(255),
 IdCategoria INT,
 Estado BIT DEFAULT 1,
 FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);

CREATE TABLE FelDocumentos(
 IdFel INT IDENTITY PRIMARY KEY,
 IdFactura INT,
 UUID VARCHAR(100),
 Serie VARCHAR(20),
 Numero VARCHAR(20),
 FechaAutorizacion DATETIME,
 Estado VARCHAR(50),
 XMLGenerado VARCHAR(MAX),
 FOREIGN KEY (IdFactura) REFERENCES Facturas(IdFactura)
);


