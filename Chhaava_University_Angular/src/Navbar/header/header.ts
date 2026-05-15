import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Service } from '../../Auth/service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './header.html',
  styleUrls: ['./header.css'],
})
export class Header implements OnInit {

  isLoggedIn: boolean = false;
  username: string = '';

  constructor(private Service: Service, private router: Router) {}

  ngOnInit() {
    this.checkLoginStatus();
  }

  checkLoginStatus() {
    const token = localStorage.getItem('token');
    this.isLoggedIn = !!token;
    if (this.isLoggedIn) {
      this.username = localStorage.getItem('username') || 'User';
    }
  }

  logout() {
    this.Service._logout().subscribe({
      next: (response) => {
        console.log('Logout successful:', response);
        localStorage.removeItem('token');
        localStorage.removeItem('role');
        localStorage.removeItem('username');
        this.isLoggedIn = false;
        this.username = '';
        alert('Logout successful');
        this.router.navigate(['/login']);
      },
      error: (error) => {
        console.error('Logout failed:', error);
      }
    });
  }
}
