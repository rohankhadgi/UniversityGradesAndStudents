import { Component, OnInit } from '@angular/core';
import { Course } from '../shared-services/courses.model';
import { CourseService } from '../shared-services/courses.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styles: [
  ]
})
export class CoursesComponent implements OnInit {

  constructor(public coursesService: CourseService) { }

  ngOnInit(): void {
    this.coursesService.refreshCoursesList();
  }

  onDelete(courseID: number) {

  }

  updateCourse(course: Course) {
    this.coursesService.courseFormData = Object.assign({}, course);
  }
}
