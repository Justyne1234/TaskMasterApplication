CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteTask`(IN task_id int)
BEGIN
	DELETE FROM taskdb.tasks
    WHERE Id = task_id;
END