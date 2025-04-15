USE [MonsterSchoolDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cali Crouse
-- Create date: 11/15/24
-- Description:	A procedure for the MonsterSchool Database that finds all students that enrolled after October.
-- =============================================

CREATE PROCEDURE [dbo].[EnrollmentsAfterOctober]
	@EnrollmentsAfterDate VARCHAR(10)
AS BEGIN
	SELECT StudentId, CourseId, EnrollDate
	FROM [MonsterSchoolDB].[dbo].Enrollment
	WHERE EnrollDate > '2024-10-1'
	ORDER BY EnrollDate
END

GO
