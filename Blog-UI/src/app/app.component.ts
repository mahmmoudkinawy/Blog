import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Blog-UI';

  getDateOfTheCurrentYear() {
    return new Date().getFullYear();
  }

}
