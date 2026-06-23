import { HttpErrorResponse, HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { catchError, throwError } from "rxjs";

export const exceptionInterceptor: HttpInterceptorFn = (req, next) => {

    const snackBar = inject(MatSnackBar);
    
    return next(req).pipe(
        catchError((error: HttpErrorResponse) => {
            const errorMessage = error?.error?.message  || "Unexpected Error Occured!";

            snackBar.open(
                errorMessage,
                'Close',
                {
                    duration: 5000,
                    horizontalPosition: 'center',
                    verticalPosition: 'top'
                }
            );
            return throwError(() =>({
               status: error.status,
               message: errorMessage
            }));
        })
    );
}