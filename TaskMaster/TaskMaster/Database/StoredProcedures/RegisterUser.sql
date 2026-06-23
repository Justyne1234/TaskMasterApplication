CREATE DEFINER=`root`@`localhost` PROCEDURE `RegisterUser`(
    IN user_UserName VARCHAR(100),
    IN user_Password VARCHAR(255)
)
BEGIN
    INSERT INTO Users (UserName, Password)
    VALUES (user_UserName, user_Password);
END