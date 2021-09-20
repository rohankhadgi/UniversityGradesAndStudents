import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Student } from 'src/app/shared-services/students.model';
import { StudentsService } from 'src/app/shared-services/students.service';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { CourseService } from 'src/app/shared-services/courses.service';
import { Course } from 'src/app/shared-services/courses.model';
import { StudentCourse } from 'src/app/shared-services/studentcourses.model';
import { Observable } from 'rxjs';
import { CourseGradeDropdownOptions } from 'src/app/shared-services/course-grade-dropdown-options';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styles: [
  ]
})

export class StudentFormComponent implements OnInit {

  dropdownList: Observable<any>;
  selectedItems: any[] = [];
  dropdownSettings: IDropdownSettings

  coursesAndGrades: any[] = [];

  courseGradeDropdownList: any[] = [];
  courseGradeDropdownSettings: IDropdownSettings;

  constructor(public studentService: StudentsService,
    public courseService: CourseService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.dropdownList = this.courseService.getCourses();
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'courseID',
      textField: 'courseName',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      allowSearchFilter: true
    };
    this.courseGradeDropdownSettings = {
      singleSelection: true,
      idField: 'courseID',
      textField: 'grade',
      allowSearchFilter: true
    };
  }

  onItemSelect(item: any) {
    this.selectedItems.push(item);
  }

  onSelectAll(items: any[]) {
    items.forEach(element => {
      this.selectedItems.push(element);
    });
  }

  createCoursesAndGrades() {
    this.coursesAndGrades.forEach(element => {
      this.studentService.studentFormData.studentCourses.push(new StudentCourse(this.studentService.studentFormData.studentID, element.courseID, element.grade, true))
    });
  }

  getCourseGradeDropDownList(courseID: number) {

    const dropdownListOptions: CourseGradeDropdownOptions[] = [
      new CourseGradeDropdownOptions(courseID, 'A'),
      new CourseGradeDropdownOptions(courseID, 'B'),
      new CourseGradeDropdownOptions(courseID, 'C'),
      new CourseGradeDropdownOptions(courseID, 'D'),
      new CourseGradeDropdownOptions(courseID, 'F'),
    ];

    return dropdownListOptions;
  }

  onCourseGradeItemSelect(item: any) {
    this.coursesAndGrades.push(item);
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
