import { Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { TaskListComponent } from './features/tasks/task-page/task-list/task-list.component';
import { TaskPageComponent } from './features/tasks/task-page/task-page.component';
import { RegisterComponent } from './features/auth/register/register.component';
import { authGuard } from './shared/guard/auth.guard';
import { TaskFormComponent } from './features/tasks/task-page/task-form/task-form.component';
import { TaskDetailsComponent } from './features/tasks/task-page/task-details/task-details.components';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {
        path: 'tasks',
        component: TaskPageComponent,
        canActivate: [authGuard],
        children: [
            {path: '', component: TaskListComponent, canActivate: [authGuard]},
            {path: 'create-task', component: TaskFormComponent, canActivate: [authGuard]},
            {path: ':id', component: TaskDetailsComponent, canActivate: [authGuard]},
            {path: ':id/edit', component: TaskFormComponent, canActivate: [authGuard]}
        ]
    }
];