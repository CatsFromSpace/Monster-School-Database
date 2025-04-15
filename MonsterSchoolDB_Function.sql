USE LakeShore

GO

-- =============================================
-- Author:		Cali Crouse
-- Create date: 11/15/24
-- Description:	A function for the MonsterSchool Database that returns student enrollment date given student ID
-- =============================================

IF OBJECT_ID(N'dbo.enrollDateById', N'FN') IS NOT NULL
	DROP FUNCTION dbo.enrollDateById;
GO

CREATE FUNCTION enrollDateById
	(@StudentId INT)
	RETURNS VARCHAR(10)
AS BEGIN
	DECLARE @EnrollDate VARCHAR(10)

	SET @EnrollDate = 0;

	SELECT @EnrollDate = EnrollDate
	FROM [MonsterSchoolDB].[dbo].[Enrollment]
	WHERE IsEnrolled = 1 AND StudentId = @StudentId

	RETURN @EnrollDate
END

GO

SELECT dbo.enrollDateById(2)