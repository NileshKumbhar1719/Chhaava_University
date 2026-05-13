import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';

interface LoginData {
  email: string;
  password: string;
}

@Injectable({
  providedIn: 'root',
})
export class Service {

  private baseUrl = 'http://localhost:7000/api';

  constructor(private http: HttpClient) {}

  _login(data: LoginData): Observable<any> {
    return this.http.post(`${this.baseUrl}/Authe/login`, data)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: any) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Client Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = `Server Error Code: ${error.status} | Message: ${error.message}`;
    }

    console.error(errorMessage);
    return throwError(() => errorMessage);
  }
}