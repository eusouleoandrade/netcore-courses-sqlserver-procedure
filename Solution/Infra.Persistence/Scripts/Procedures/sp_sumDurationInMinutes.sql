SELECT *
FROM dbo.Course

SELECT DISTINCT(Tag) ,*
FROM dbo.Course

--Criar uma procedure que recebe o Level e faz a soma do DurationInMinutes para aquele Level

-- Remoção da procedure

DROP PROCEDURE sp_sumDurationInMinutes

-- Criação da procedure

IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'sp_sumDurationInMinutes'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.[sp_sumDurationInMinutes]
GO

CREATE PROCEDURE sp_sumDurationInMinutes 
	@LEVEL AS INT OUTPUT,
	@COUNT_LEVEL AS INT OUTPUT,
	@DURATION AS INT OUTPUT
AS
BEGIN
	SET @COUNT_LEVEL = 0
	SET @DURATION = 0

	SELECT @DURATION = ISNULL(SUM([DurationInMinutes]), 0),
		@COUNT_LEVEL = ISNULL(COUNT([Level]), 0)
	FROM dbo.[Course]
	WHERE [Level] = @LEVEL
END

--Chamada da procedure

DECLARE @COUNT_LEVEL AS INT
DECLARE @DURATION AS INT
DECLARE @LEVEL AS INT

SET @LEVEL = 44

EXEC sp_sumDurationInMinutes @LEVEL = @LEVEL, @COUNT_LEVEL = @COUNT_LEVEL OUTPUT, @DURATION = @DURATION OUTPUT

PRINT @COUNT_LEVEL
PRINT @DURATION
PRINT @LEVEL

-- Teste de consulta

SELECT SUM([DurationInMinutes]),
		COUNT([Level])
	FROM dbo.[Course]
	WHERE [Level] = 2