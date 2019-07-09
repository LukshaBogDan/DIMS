CREATE PROCEDURE [dbo].[DeleteUser]
	@UserId int = 0
AS
	BEGIN
		DELETE FROM [UserProfile]
		WHERE UserId = @UserId
	END

