import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GradeCalculationClient';

  navLinks = [ 
    { path: 'courses', label: 'Courses' },
    { path: 'students', label: 'Students' }
  ];

  constructor() {

  }
}
