export class CourseGradeDropdownOptions {
  courseID: number;
  grade: string;

  constructor(courseID: number, grade: string) {
    this.courseID = courseID;
    this.grade = grade;
  }
}
