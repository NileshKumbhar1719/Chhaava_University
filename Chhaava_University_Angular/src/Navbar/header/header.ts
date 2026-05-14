import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Service } from '../../Auth/service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './header.html',
  styleUrls: ['./header.css'],
})
export class Header {

  constructor(private Service: Service, private router: Router) {}

  logout() {
    this.Service._logout().subscribe({
      next: (response) => {
        console.log('Logout successful:', response);
        localStorage.removeItem('token');
        localStorage.removeItem('role');
        alert('Logout successful');
        this.router.navigate(['/login']);
      },
      error: (error) => {
        console.error('Logout failed:', error);
      }
    });
  }
}
