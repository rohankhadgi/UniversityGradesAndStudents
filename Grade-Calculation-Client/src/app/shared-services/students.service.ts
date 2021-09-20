import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from './students.model';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  studentFormData: Student = new Student();
  studentsList: Student[];

  readonly baseURL = 'http://localhost:64539/api/Students';

  constructor(private httpClient: HttpClient) { }

  addNewStudent() {
    return this.httpClient.post(this.baseURL, this.studentFormData);
  }

  updateStudent() {
    return this.httpClient.put(`${this.baseURL}/${this.studentFormData.studentID}`, this.studentFormData);
  }

  refreshStudentsList() {
    return this.httpClient.get(this.baseURL)
      .toPromise()
      .then(val => this.studentsList = val as Student[]);
  }

  deleteStudent(StudentID: number) {

  }
}
