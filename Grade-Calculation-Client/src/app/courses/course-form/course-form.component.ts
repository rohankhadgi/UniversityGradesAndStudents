import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Course } from 'src/app/shared-services/courses.model';
import { CourseService } from 'src/app/shared-services/courses.service';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styles: [
  ]
})
export class CourseFormComponent implements OnInit {

  constructor(public courseService: CourseService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.courseService.courseFormData.courseID == 0)
      this.insertCourse(form);
    else
      this.updateCourse(form);
  }

  insertCourse(form: NgForm) {
    this.courseService.addNewCourse().subscribe(
      val => {
        this.onPostComplete(form);
        this.toastr.success("Course added successfully", "Success");
      }
    );
  }

  updateCourse(form: NgForm) {
    this.courseService.updateCourse().subscribe(
      val => {
        this.onPostComplete(form);
        this.toastr.info("Course updated successfully", "Success");
      }
    );
  }

  onPostComplete(form: NgForm) {
    form.form.reset();
    this.courseService.courseFormData = new Course();
    this.courseService.refreshCoursesList();
  }
}
