CREATE DATABASE ControlCuentas
USE ControlCuentas

CREATE TABLE TipoCuenta(
	idTipoCuenta INT IDENTITY (1,1) NOT NULL,
	tipoCuenta VARCHAR(10) NOT NULL,
	PRIMARY KEY(idTipoCuenta)
);

CREATE TABLE Cliente(
	idCliente INT IDENTITY (1,1) NOT NULL,
	nombreCliente VARCHAR(50) NOT NULL,
	apellidoCliente VARCHAR (50) NOT NULL,
	PRIMARY KEY(idCliente)
);

CREATE TABLE Cuenta(
	idCuenta INT IDENTITY (1,1) NOT NULL,
	numeroCuenta VARCHAR(20) NOT NULL,
	nombreCuenta VARCHAR(50) NOT NULL,
	idCliente INT NOT NULL,
	tipoMoneda INT NOT NULL,
	idTipoCuenta INT NOT NULL,
	esCuentaTercero INT NOT NULL,
	PRIMARY KEY(idCuenta),
	FOREIGN KEY(idCliente) REFERENCES Cliente(idCliente),
	FOREIGN KEY(idTipoCuenta) REFERENCES TipoCuenta(idTipoCuenta)
);

INSERT INTO Cuenta(numeroCuenta, nombreCuenta, idCliente, tipoMoneda, idTipoCuenta, esCuentaTercero)
VALUES('001-12345-7','CUENTA PERSONAL KEYLER', 1, 0, 1, 0);

INSERT INTO Cuenta(numeroCuenta, nombreCuenta, idCliente, tipoMoneda, idTipoCuenta, esCuentaTercero)
VALUES('002-54321-6','CUENTA PERSONAL FERNANDO', 1, 1, 1, 1);

GO
CREATE PROCEDURE sp_cuentas
@numeroCuenta VARCHAR(20),
@nombreCuenta VARCHAR(50),
@idCliente INT,
@tipoMoneda INT,
@idTipoCuenta INT,
@esCuentaTercero INT
AS
SELECT c.numeroCuenta, c.nombreCuenta, cl.nombreCliente, tc.tipoCuenta,
CASE 
	WHEN c.tipoMoneda = 0 THEN 'Quetzales'
	WHEN c.tipoMoneda = 1 THEN 'Dolares'
END AS TipoMoneda,
CASE 
	WHEN c.esCuentaTercero = 0 THEN 'Propia'
	WHEN c.esCuentaTercero = 1 THEN 'Terceros'
	END AS Cuenta
FROM Cuenta c
INNER JOIN Cliente cl ON cl.idCliente = c.idCliente
INNER JOIN TipoCuenta tc ON tc.idTipoCuenta = c.idTipoCuenta
BEGIN
	INSERT INTO Cuenta(numeroCuenta, nombreCuenta, idCliente, tipoMoneda, idTipoCuenta, esCuentaTercero)
	VALUES(@numeroCuenta, @nombreCuenta, @idCliente, @tipoMoneda, @idTipoCuenta, @esCuentaTercero)
END

EXEC sp_cuentas @numeroCuenta = '002-45678-5', @nombreCuenta = 'CUENTA KEYLER FERNANDO', @idCliente = 1,
@tipoMoneda = 0, @idTipoCuenta = 1, @esCuentaTercero = 0;

CREATE PROCEDURE sp_cuentasSelect
AS
BEGIN
SELECT c.numeroCuenta, c.nombreCuenta, cl.nombreCliente, tc.tipoCuenta,
CASE 
	WHEN c.tipoMoneda = 0 THEN 'Quetzales'
	WHEN c.tipoMoneda = 1 THEN 'Dolares'
END AS TipoMoneda,
CASE 
	WHEN c.esCuentaTercero = 0 THEN 'Propia'
	WHEN c.esCuentaTercero = 1 THEN 'Terceros'
	END AS Cuenta
FROM Cuenta c
INNER JOIN Cliente cl ON cl.idCliente = c.idCliente
INNER JOIN TipoCuenta tc ON tc.idTipoCuenta = c.idTipoCuenta
END

