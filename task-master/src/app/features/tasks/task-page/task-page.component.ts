import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { map, Observable } from 'rxjs';
import { TaskResponse } from '../../../shared/models/task-response.model';
import { TaskService } from '../../../shared/services/task.service';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-task-page',
  imports: [
    CommonModule,
    RouterOutlet
  ],
  templateUrl: './task-page.html',
  styleUrl: './task-page.scss',
})
export class TaskPageComponent {
  mode: string = "list";
  selectedTask: TaskResponse | null = null;

  tasks$!: Observable<TaskResponse[]>;

  constructor(private router: Router){}

  onCreate(){
    console.log("on create clicked!");
    this.router.navigate(['/tasks/create-task']);
  }
  toDashBoard(){
    this.router.navigate(['/tasks']);
  }
}
