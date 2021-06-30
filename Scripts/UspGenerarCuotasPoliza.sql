
CREATE PROCEDURE [dbo].[UspGenerarCuotasPoliza]
@Recibo as INT,
@Cuotas as INT,
@Vencimiento as DATE
AS
BEGIN
	
	DECLARE @NoCuota INT;
	DECLARE @MontoCuota MONEY;
	DECLARE @Total MONEY;
	
	SET @Total = (SELECT p.TotalPrima FROM Poliza AS p WHERE p.IdRecibo = @Recibo)
	
	SET @NoCuota = 1;
	
	SET @MontoCuota = @Total / @Cuotas;
	
	WHILE ( @NoCuota <= @Cuotas)
	BEGIN
		
		INSERT INTO CuotasPoliza
		(			
			IdRecibo,
			NoCuota,
			FechaVencimiento,
			MontoCuota,
			FechaPago,
			MontoPagado,
			Pagado
		)
		VALUES
		(
			@Recibo,
			@NoCuota,
			@Vencimiento,
			@MontoCuota,
			NULL,
			0,
			'N'
		)
		
		
		set @Vencimiento = DATEADD(MONTH,1,@Vencimiento)
		SET @NoCuota = @NoCuota + 1;
	END
	
END

GO