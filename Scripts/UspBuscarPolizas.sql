CREATE PROCEDURE [dbo].[UspBuscarPolizas]
@Identificacion AS VARCHAR(20) = NULL,
@NumeroPoliza AS VARCHAR(20) = NULL,
@Recibo as INT = NULL,
@Desde AS DATE = NULL,
@Hasta AS DATE = NULL
AS
BEGIN
	
	SELECT p.NumeroPoliza,p.IdRecibo, p.FechaVenta,cm.Moneda,p.TotalPrima,
	(CASE p.CodMoneda 
		WHEN 2 THEN ctc.TipoCambio * p.TotalPrima
		WHEN 1 THEN p.TotalPrima
		ELSE p.TotalPrima END) AS MontoCordobizado,
	c.NombreCliente,cp.xpais,cd.xdepartamento,
	(SELECT SUM(MontoSumaAsegurada) FROM CoberturasPoliza AS cp2 WHERE cp2.IdRecibo = p.IdRecibo AND cp2.Isuma = 'S') AS TotalSa
	  FROM Clientes AS c
	JOIN Poliza AS p ON p.IdContrantante = c.IdCliente
	JOIN CatMoneda AS cm ON cm.CodMoneda = p.CodMoneda
	JOIN CatPais AS cp ON cp.CodPais = c.CodPais 
	JOIN CatDepartamento AS cd ON cd.CodPais = c.CodPais AND cd.CodDepartamento = c.CodDepartamento
	LEFT JOIN CatTipoCambio AS ctc ON p.FechaVenta = ctc.Fecha
	WHERE 
		(@Identificacion IS NULL OR c.Identificacion = @Identificacion)
		AND (@NumeroPoliza IS NULL OR p.NumeroPoliza = @NumeroPoliza)
		AND (@Recibo IS NULL OR p.IdRecibo = @Recibo)
		AND ((@Desde IS NULL AND @Hasta IS NULL) OR (p.FechaVenta >= @Desde AND p.FechaVenta <= @Hasta))
	
END

GO
