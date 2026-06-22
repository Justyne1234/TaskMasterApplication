import { Component } from '@angular/core';
import { TaskResponse } from '../../../../shared/models/task-response.model';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../../../shared/services/task.service';
import { Observable } from 'rxjs';
import { TaskUtils } from '../../../../shared/utils/task.utils';

@Component({
  selector: 'app-task-details',
  imports: [CommonModule],
  templateUrl: './task-details.html',
  styleUrl: './task-details.scss',
})
export class TaskDetailsComponent {
  task$!: Observable<TaskResponse>;
  taskId?: string | null;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private taskService: TaskService){}

  ngOnInit(){
    this.taskId = this.route.snapshot.paramMap.get('id');
    if(this.taskId){
      this.task$ = this.taskService.getTaskById(this.taskId);
    }
  }
  onDeleteTask(){
    if(this.taskId){
      this.taskService.deleteTask(this.taskId).subscribe();
      this.router.navigate(['/tasks']);
    }
  }
  onEditTask(){
    this.router.navigate(['/tasks', this.taskId, 'edit']);
  }
  onReturn(){
    this.router.navigate(['/tasks']);
  }
  formatStatus(status: string)
  {
    return TaskUtils.formatStatus(status);
  }
}
