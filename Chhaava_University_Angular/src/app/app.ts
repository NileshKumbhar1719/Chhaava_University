import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { Footer } from '../Navbar/footer/footer';
import { Header } from '../Navbar/header/header';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Header,Footer,RouterModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Chhaava_University_Angular';
}
