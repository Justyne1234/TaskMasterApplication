import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskResponse } from '../../../../shared/models/task-response.model';
import { TaskService } from '../../../../shared/services/task.service';
import { TaskEditRequest } from '../../../../shared/models/task-edit-request.model';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskUtils } from '../../../../shared/utils/task.utils';


@Component({
  selector: 'app-task-list',
  imports: [CommonModule],
  templateUrl: './task-list.html',
  styleUrl: './task-list.scss',
})
export class TaskListComponent {
  tasks$!: Observable<TaskResponse[]>;

  constructor(
    private taskService: TaskService,
    private router: Router,
    private route: ActivatedRoute){}

  ngOnInit(){
    this.tasks$ = this.taskService.getTasks();
  }

  onSelectTask(id: number){
    this.router.navigate(['/tasks', id])
  }

  formatStatus(status: string)
  {
    return TaskUtils.formatStatus(status);
  }
}
