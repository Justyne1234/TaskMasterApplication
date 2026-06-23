CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateTask`(
    IN task_Id INT,
    IN task_Title VARCHAR(255),
    IN task_Description TEXT,
    IN task_DueDate DATETIME,
    IN task_Category VARCHAR(100),
    IN task_Priority INT,
    IN task_Status VARCHAR(50)
)
BEGIN
    UPDATE taskdb.tasks
    SET
        Title = task_Title,
        Description = task_Description,
        DueDate = task_DueDate,
        Category = task_Category,
        Priority = task_Priority,
        Status = task_Status
    WHERE Id = task_Id;
END