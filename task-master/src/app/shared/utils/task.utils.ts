export class TaskUtils{
    static formatStatus(status: string): string {
        switch (status) {
        case 'ToDo':
            return 'To Do';

        case 'InProgress':
            return 'In progress';

        default:
            return status;
        }
    }
}