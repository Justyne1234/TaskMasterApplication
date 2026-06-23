CREATE DEFINER=`root`@`localhost` PROCEDURE `RegisterUser`(
    IN user_UserName VARCHAR(100),
    IN user_Password VARCHAR(255),
    IN user_AuthenticationMethod VARCHAR(50),
    IN user_GoogleId VARCHAR(255)
)
BEGIN
    INSERT INTO taskdb.users (UserName, Password, AuthenticationMethod, GoogleId)
    VALUES (user_UserName, user_Password, user_AuthenticationMethod, user_GoogleId);
END