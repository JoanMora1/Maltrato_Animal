CREATE DATABASE PROTECT_ANIMALS
USE PROTECT_ANIMALS

CREATE TABLE REPORTE(
ID_REPORTE INT IDENtity (1,1) NOT NULL PRIMARY KEY,
NOMBRE NVARCHAR(50) NOT NULL,
APELLIDO NVARCHAR(50) NOT NULL,
CORREO NVARCHAR(100) NOT NULL,
TELEFONO NVARCHAR(20) NOT NULL,
FOTO IMAGE NOT NULL
)

CREATE PROC SP_INSERTAR_REPORTE
@NOMBRE NVARCHAR(50),
@APELLIDO NVARCHAR(50),
@CORREO NVARCHAR(100),
@TELEFONO NVARCHAR(20),
@FOTO IMAGE
AS
INSERT INTO REPORTE(NOMBRE,APELLIDO,CORREO,TELEFONO,FOTO) VALUES (@NOMBRE,@APELLIDO,@CORREO,@TELEFONO,@FOTO)

CREATE PROC SP_EDITAR_REPORTE
@ID_REPORTE INT,
@NOMBRE NVARCHAR(50),
@APELLIDO NVARCHAR(50),
@CORREO NVARCHAR(100),
@TELEFONO NVARCHAR(20),
@FOTO IMAGE
AS
UPDATE REPORTE SET NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, CORREO=@CORREO, TELEFONO=@TELEFONO, FOTO=@FOTO
WHERE ID_REPORTE=@ID_REPORTE

CREATE PROC SP_BUSCAR_REPORTE
@BUSCAR NVARCHAR(50)
AS
SELECT * FROM REPORTE WHERE NOMBRE LIKE @BUSCAR + '%'

CREATE PROC SP_ELIMINAR_REPORTE
@ID_REPORTE INT
AS
DELETE REPORTE WHERE ID_REPORTE=@ID_REPORTE