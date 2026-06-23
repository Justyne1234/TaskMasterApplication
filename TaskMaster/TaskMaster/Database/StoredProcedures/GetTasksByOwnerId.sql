CREATE PROCEDURE GetAllTasksByOwnerId (IN owner_id int)
BEGIN
	SELECT
		Id,
        OwnerId,
        Title,
        Description,
        DueDate,
        Category,
        Priority,
        Status
    FROM taskdb.tasks
	WHERE OwnerId = owner_id;
END
