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

    static contractDescription(description: string): string {
        if( description.length > 20 ){
            return `${description.slice(0, 20)} ... see more`;
        }
        return description;
    }
}