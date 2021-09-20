export class CourseGradeDropdownOptions {
  courseID: number;
  grade: number;
  gradeViewValue: string;

  constructor(courseID: number, grade: number, viewValue: string) {
    this.courseID = courseID;
    this.grade = grade;
    this.gradeViewValue = viewValue;
  }
}
