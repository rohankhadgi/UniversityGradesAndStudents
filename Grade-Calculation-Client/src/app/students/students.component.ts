import { Component, OnInit } from '@angular/core';
import { Student } from '../shared-services/students.model';
import { StudentsService } from '../shared-services/students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styles: [
  ]
})
export class StudentsComponent implements OnInit {

  showStudentCourses = false;
  
  constructor(public studentsService: StudentsService) { }

  ngOnInit(): void {
    this.studentsService.refreshStudentsList();
  }

  onDelete(studentID: number) {

  }

  getStudentCourses(courseID: number) {
    return this.studentsService.getStudentCourses(courseID);
  }


  updateStudent(event: any) {
    const student = event.dataItem;
    this.studentsService.studentFormData = Object.assign({}, student);
  }
  
  toggleStudentCourses() {
    this.showStudentCourses = !this.showStudentCourses;
  }
}
