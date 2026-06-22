import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../shared/services/auth.service';
import { Router, RouterModule } from '@angular/router';
import { environment } from '../../../../environments/environment';

declare const google: any;

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class LoginComponent {
  username: string = 'test';
  password: string = 'test';

  errorMessage:string = '';

  constructor(private authService: AuthService,
    private router: Router){}

  ngOnInit(){
    const waitForGoogle = () => {
      if (!window.google?.accounts) {
        setTimeout(waitForGoogle, 50);
        return;
      }
      google.accounts.id.initialize({
        client_id: environment.CLIENT_ID,
        callback: this.handleCallback.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true
      });

      google.accounts.id.renderButton(
          document.getElementById('google-button'),
          {
            theme: 'outline',
            size: 'large'
          }
        );
      }
    waitForGoogle();
  }

  onLogin(){
    this.authService.login(this.username, this.password)
    .subscribe({
      next: () => {
        this.router.navigate(['/tasks']);
      },
      error: (err) => {
        console.log("login component error");
        this.errorMessage = err.message;
      },
    });
  }

  handleCallback(response: any){
    this.authService.googleLogin(response.credential)
    .subscribe({
      next: () => {
        this.router.navigate(['/tasks']);
      },
      error: (err) => {
        this.errorMessage = err.message;
      },
    });
  }
}
