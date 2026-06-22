import { CanActivateFn, Router } from "@angular/router";

export const authGuard: CanActivateFn = () => {
    const router = new Router();

    if(localStorage.getItem("token")){
        return true;
    }
    else{
        return router.navigate(['/login']);
    }
};