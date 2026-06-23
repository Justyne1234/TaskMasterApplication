CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserByUsername`(IN user_username VARCHAR(100))
BEGIN
	SELECT  * FROM taskdb.users
    WHERE  Username = user_username;
END