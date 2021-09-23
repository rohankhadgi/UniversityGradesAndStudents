import { Injectable } from '@angular/core';
import { Course } from './courses.model';
import { HttpClient } from '@angular/common/http';
import { StudentCourse } from './studentcourses.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  
  courseFormData: Course = new Course();
  coursesList: Course[];
  enrolledStudents: any[];

  readonly baseURL = 'http://localhost:64539/api/Courses';

  constructor(private httpClient: HttpClient) { }

  addNewCourse() {
    return this.httpClient.post(this.baseURL, this.courseFormData);
  }

  updateCourse() {
    return this.httpClient.put(`${this.baseURL}/${this.courseFormData.courseID}`, this.courseFormData);
  }

  refreshCoursesList() {
    return this.httpClient.get(this.baseURL)
      .toPromise()
      .then(val => this.coursesList = val as Course[]);
  }

  getCourses() {    
    return this.httpClient.get(this.baseURL);
  }

  getEnrolledStudents(courseID: number) {
    this.httpClient.get(`${this.baseURL}/course/${courseID}/get-enrolled-students`)
    .toPromise()
    .then(val => this.enrolledStudents = val as any[]);

    return this.enrolledStudents;
  }

  deleteCourse(courseID: number) {

  }
}
