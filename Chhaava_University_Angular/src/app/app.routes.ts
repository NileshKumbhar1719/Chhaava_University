import { Routes } from '@angular/router';
import { Component } from '@angular/core';
import { Home } from '../Navbar/home/home';
import { Login } from '../Auth/login/login';
import { Register } from '../Auth/register/register';

export const routes: Routes = [
    {path: '', redirectTo: 'home', pathMatch: 'full'},
    {path: 'home', component: Home},
    {path:'login',component:Login  },
    {path:'register',component:Register  },
    
];
