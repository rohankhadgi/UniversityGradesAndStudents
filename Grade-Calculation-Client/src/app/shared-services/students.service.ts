import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from './students.model';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  studentFormData: Student = new Student();
  studentsList: Student[];

  stundentCourses: any[];

  readonly baseURL = 'http://localhost:64539/api/Students';

  constructor(private httpClient: HttpClient) { }

  addNewStudent() {
    return this.httpClient.post(this.baseURL, this.studentFormData);
  }

  updateStudent() {
    return this.httpClient.put(`${this.baseURL}/${this.studentFormData.studentID}`, this.studentFormData);
  }

  getStudentCourses(studentID: number) {
    this.httpClient.get(`${this.baseURL}/student/${studentID}/get-student-courses`)
    .toPromise()
    .then(val => this.stundentCourses = val as any[]);

    console.log('student courses: ', this.stundentCourses);

    return this.stundentCourses;
  }

  refreshStudentsList() {
    return this.httpClient.get(this.baseURL)
      .toPromise()
      .then(val => this.studentsList = val as Student[]);
  }

  deleteStudent(StudentID: number) {

  }
}
