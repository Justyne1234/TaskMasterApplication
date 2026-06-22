import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, tap, throwError } from 'rxjs';
import { LoginResponse } from '../models/login-response.model';
import { environment } from '../../../environments/environment';

declare const google: any;
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private url = `${environment.BASE_URL}/user`;

  private isLoggedInSubject = new BehaviorSubject<boolean>(
    !!localStorage.getItem("token")
  );

  isLoggedIn$ = this.isLoggedInSubject.asObservable();

  constructor(private httpClient: HttpClient){}

  login(username: string, password: string){
    console.log("login service");
    const payload = {
      username, password
    }
    return this.httpClient.post<LoginResponse>(`${this.url}/login`, payload)
    .pipe(
      tap(response => {
      localStorage.setItem("token", response.token);

      const payload = JSON.parse(atob(response.token.split('.')[1]));
      const id = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

      localStorage.setItem("id", id);
      this.isLoggedInSubject.next(true);
      }),
      catchError(error => {
        return throwError(() => new Error(error.error.message));
      })
    );
  }
  googleLogin(credential: string){
    const payload = {
      "googleToken": credential
    }
    return this.httpClient.post<LoginResponse>(`${this.url}/google-login`, payload)
    .pipe(
      tap(response => {
        localStorage.setItem("token", response.token);

        const payload = JSON.parse(atob(response.token.split('.')[1]));
        const id = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

        localStorage.setItem("id", id);
        this.isLoggedInSubject.next(true);
      }),
      catchError(error => {
          return throwError(() => new Error(error?.error?.message));
      })
    );
  }
  register(username: string, password: string){
    const payload = {
      username, password
    }
    return this.httpClient.post(`${this.url}/register`, payload).
    pipe(
      catchError(error => {
          return throwError(() => new Error(error?.error?.message));
      })
    );
  }

  getToken(): string | null {
    return localStorage.getItem("token");
  }

  getUserId(): string | null {
    return localStorage.getItem("userId");
  }

  logout(){
    localStorage.removeItem("token");
    this.isLoggedInSubject.next(false);
  }
}
