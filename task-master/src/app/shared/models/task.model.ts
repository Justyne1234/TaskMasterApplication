import { Category } from "./category.model";
import { Priority } from "./priority.model";
import { Status } from "./status.model";

export interface Task{
    title: string;
    description?: string;
    dueDate?: string;
    priority: Priority;
    category?: Category | null;
    status: Status
}