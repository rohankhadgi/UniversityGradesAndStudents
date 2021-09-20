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

  constructor(public studentsService: StudentsService) { }

  ngOnInit(): void {
    this.studentsService.refreshStudentsList();
  }

  onDelete(studentID: number) {

  }

  updateStudent(student: Student) {
    this.studentsService.studentFormData = Object.assign({}, student);
  }
}
