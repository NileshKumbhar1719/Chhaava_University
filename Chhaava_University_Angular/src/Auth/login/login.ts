import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Service } from '../service';

interface LoginData {
  email: string;
  password: string;
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {

  email: string = '';
  password: string = '';

  constructor(private service: Service) {}

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
        alert('Login successful');
      },

      error: (error) => {
        console.error('Login failed:', error);
        alert(error.error?.message || 'Login failed');
      }
    });
  }
}