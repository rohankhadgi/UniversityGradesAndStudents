import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Student } from 'src/app/shared-services/students.model';
import { StudentsService } from 'src/app/shared-services/students.service';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styles: [
  ]
})
export class StudentFormComponent implements OnInit {

  constructor(public studentService: StudentsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.studentService.studentFormData.studentID == 0)
      this.insertStudent(form);
    else
      this.updateStudent(form);
  }

  insertStudent(form: NgForm) {
    this.studentService.addNewStudent().subscribe(
      val => {
        this.onPostComplete(form);
        this.toastr.success("Student added successfully", "Success");
      }
    );
  }

  updateStudent(form: NgForm) {
    this.studentService.updateStudent().subscribe(
      val => {
        this.onPostComplete(form);
        this.toastr.info("Student updated successfully", "Success");
      }
    );
  }

  onPostComplete(form: NgForm) {
    form.form.reset();
    this.studentService.studentFormData = new Student();
    this.studentService.refreshStudentsList();
  }
}
