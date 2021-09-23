import { Component, OnInit } from '@angular/core';
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

  getEnrolledStudents(courseID: number) {
    return this.coursesService.getEnrolledStudents(courseID);
  }

  updateCourse(event: any) {
    const course = event.dataItem;
    this.coursesService.courseFormData = Object.assign({}, course);
  }
}
