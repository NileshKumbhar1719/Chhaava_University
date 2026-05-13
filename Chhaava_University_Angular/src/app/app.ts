import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Footer } from '../Navbar/footer/footer';
import { Header } from '../Navbar/header/header';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Header, Footer],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected title = 'Chhaava_University_Angular';
}
