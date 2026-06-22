import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Task } from '../models/task.model';
import { BehaviorSubject, catchError, Observable, switchMap, throwError } from 'rxjs';
import { TaskResponse } from '../models/task-response.model';
import { TaskEditRequest } from '../models/task-edit-request.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private url = `${environment.BASE_URL}/task`;
  private tasksRefreshTrigger$ = new BehaviorSubject<void>(undefined);

  constructor(private httpClient: HttpClient){}

  createTask(task: Task){
    const id = localStorage.getItem("id");
    const payload = {
      "ownerId" : id,
      ... task
    };
    return this.httpClient.post(this.url, payload)
    .pipe(
      catchError(error => {
        return throwError(() => new Error(error?.error?.message));
      })
    );
  }

  getTasks(): Observable<TaskResponse[]>{
    const id = localStorage.getItem("id") ?? "1";
    const params = new HttpParams().set("ownerId", id);

    return this.tasksRefreshTrigger$.pipe(
      switchMap(() => this.httpClient.get<TaskResponse[]>(this.url, { params }))
    );
  }
  refreshTasks() {
    this.tasksRefreshTrigger$.next();
  }
  getTaskById(id: string){
    return this.httpClient.get<TaskResponse>(`${this.url}/${id}`);
  }
  editTask(task: TaskEditRequest){
    console.log("edit task");
    return this.httpClient.put<TaskResponse>(this.url, task)
    .pipe(
      catchError(error => {
          return throwError(() => new Error(error?.error?.message));
      })
    );
  }
  deleteTask(id: string){
    return this.httpClient.delete(`${this.url}/${id}`)
    .pipe(
      catchError(error => {
          return throwError(() => new Error(error?.error?.message));
      })
    );
  }
}
