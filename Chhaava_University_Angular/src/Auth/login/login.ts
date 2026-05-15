import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Service } from '../service';
import { Router, RouterLink } from '@angular/router';

interface LoginData {
  email: string;
  password: string;
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
})
export class Login {

  email: string = '';
  password: string = '';

  constructor(private service: Service,private Router: Router) {}

  login() {
    const data: LoginData = {
      email: this.email,
      password: this.password
    };

    this.service._login(data).subscribe({
      next: (response: any) => {
      console.log('Login successful:', response);

        localStorage.setItem('token', response.token);
        localStorage.setItem('role', response.role);
        localStorage.setItem('username', response.username || response.name || 'User');
        alert('Login successful');
        this.Router.navigate(['/home']);
      },

      error: (error) => {
        console.error('Login failed:', error);
        alert(error.error?.message || 'Login failed');
      }
    });
  }
}