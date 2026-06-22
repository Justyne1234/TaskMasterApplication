import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Task } from '../../../../shared/models/task.model';
import { TaskEditRequest } from '../../../../shared/models/task-edit-request.model';
import { TaskService } from '../../../../shared/services/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-task-form',
  imports: [ReactiveFormsModule],
  templateUrl: './task-form.html',
  styleUrl: './task-form.scss',
})
export class TaskFormComponent{
  form: FormGroup;
  taskId?: string | null;
  isEditMode: boolean = false;
  ownerId: number = 0;


  constructor(
    private fb: FormBuilder,
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar){
    this.form = this.buildEmptyForm();
  }

  ngOnInit(){
    this.taskId = this.route.snapshot.paramMap.get('id');

    this.isEditMode = !!this.taskId;

    if (this.isEditMode) {
      this.loadTask(this.taskId!);
    }
  }

  loadTask(id:string){
    this.taskService.getTaskById(id)
    .subscribe(task => {
        this.ownerId = task.ownerId;

        this.form.patchValue({
        title: task.title,
        description: task.description,
        dueDate: this.formatDate(task.dueDate),
        priority: task.priority,
        category: task.category,
        status: task.status
      });
    });
  }

  buildEmptyForm(){
    return this.form = this.fb.group({
      title: ['', Validators.required],
      description: [''],
      dueDate: [''],
      priority: ['', Validators.required],
      category: [''],
      status: ['ToDo', Validators.required]
    });
  }

  onSubmit(){
    if(this.isEditMode)
    {
      const payload: TaskEditRequest = {
          id: this.taskId,
          ownerId: this.ownerId,
          ...this.form.value
      };
      this.taskService.editTask(payload).subscribe(() => {
        this.back();
      });
    }
    else{
      //For missing date. Set Date today to prevent error on backend request model
      if (!this.form.value.dueDate) {
        this.form.patchValue({
          dueDate: new Date().toISOString()
        });
      }
      this.taskService.createTask(this.form.value as Task).subscribe({
        next: () => {
          this.taskService.refreshTasks();
          this.back();
        },
        error: (err: any) => {
          this.snackBar.open(
            err?.message,
            'Close',
            {
              duration: 5000,
              horizontalPosition: 'center',
              verticalPosition: 'bottom'
            }
          );
        }
      });
    }
  }
  
  back(){
    this.isEditMode ? 
      this.router.navigate(['/tasks', this.taskId])
      : this.router.navigate(['/tasks']);
  }
  private formatDate(date: any): string {
    const d = new Date(date);
    const year = d.getFullYear();
    const month = String(d.getMonth() + 1).padStart(2, '0');
    const day = String(d.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }
}
