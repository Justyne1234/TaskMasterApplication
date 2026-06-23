CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateTask`(
	IN task_Owner_id INT,
    IN task_Title VARCHAR(255),
    IN task_Description TEXT,
    IN task_DueDate DATETIME,
    IN task_Category VARCHAR(100),
    IN task_Priority INT,
    IN task_Status VARCHAR(50)
)
BEGIN
    INSERT INTO taskdb.tasks
    (
		OwnerId,
        Title,
        Description,
        DueDate,
        Category,
        Priority,
        Status
    )
    VALUES
    (
		task_Owner_id,
        task_Title,
        task_Description,
        task_DueDate,
        task_Category,
        task_Priority,
        task_Status
    );
END