import { Component } from '@angular/core';
import { Service } from '../service';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
interface RegisterData {
  firstname: string;
  lastname: string;
  username: string;
  email: string;
  password: string;
  role: string;
}

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrls: ['./register.css'],
})
export class Register {
  firstname: string = '';
  lastname: string = '';
  username: string = '';
  email: string = '';
  password: string = '';
  role: string = '';

  constructor(private Service: Service) {}

  register() {
    const registerData: RegisterData = {
      firstname: this.firstname,
      lastname: this.lastname,
      username: this.username,
      email: this.email,
      password: this.password,
      role: this.role
    };

    this.Service._register(registerData).subscribe({
      next: (response: any) => {
        console.log('Registration successful:', response);
        alert('Registration successful');
      },
      error: (error) => {
        console.error('Registration failed:', error);
        alert(error.error?.message || 'Registration failed');
      }
    });
  }
}
