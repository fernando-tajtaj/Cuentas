EXEC sp_cuentasBuscar @numeroCuenta = '001-12345-7'

INSERT INTO Cliente(nombreCliente, apellidoCliente)
VALUES('Eddy Rudy','Mejia Hernandez')

SELECT * FROM Cuenta

GO
CREATE PROCEDURE sp_clientes
AS
BEGIN
	SELECT idCliente, nombreCliente FROM Cliente
END

SELECT numeroCuenta, nombreCuenta, idCliente, idTipoCuenta, tipoMoneda, esCuentaTercero FROM Cuenta

GO
CREATE PROCEDURE sp_cuentasUpdate
@idCuenta INT,
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
END AS tipoMoneda,
CASE 
	WHEN c.esCuentaTercero = 0 THEN 'Propia'
	WHEN c.esCuentaTercero = 1 THEN 'Terceros'
	END AS Cuenta
FROM Cuenta c
INNER JOIN Cliente cl ON cl.idCliente = c.idCliente
INNER JOIN TipoCuenta tc ON tc.idTipoCuenta = c.idTipoCuenta

BEGIN
	UPDATE Cuenta SET
		numeroCuenta = @numeroCuenta, nombreCuenta = @nombreCuenta, idCliente = @idCliente, tipoMoneda = @tipoMoneda, idTipoCuenta = @idTipoCuenta, esCuentaTercero = @esCuentaTercero
	WHERE idCuenta = @idCuenta
END

GO

CREATE PROCEDURE sp_cuentasDelete
@idCuenta INT
AS
BEGIN
	DELETE FROM Cuenta WHERE idCuenta = @idCuenta
END

