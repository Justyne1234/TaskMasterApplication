import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-navbar',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class Navbar {

  isLoggedIn$!: Observable<boolean>;
  constructor(private router: Router, private authService: AuthService){
    this.isLoggedIn$ = this.authService.isLoggedIn$;
  }

  logout(){
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
