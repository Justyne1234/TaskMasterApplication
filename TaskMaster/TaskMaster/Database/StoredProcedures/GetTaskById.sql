CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTaskById`(IN task_id int)
BEGIN
	SELECT * FROM taskdb.tasks
    WHERE Id = task_id;
END