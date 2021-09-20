import { Course } from "./courses.model";
import { Student } from "./students.model";

export class StudentCourse {
    studentID: number=0;
    courseID: number=0;
    grade: string;
    isCalculated: boolean=false;
    hasPassed: boolean=false;
    student: Student;
    course: Course;

    constructor(studentID: number, courseID: number, grade: string, isCalculated: boolean) {
        this.studentID = studentID;
        this.courseID = courseID;
        this.grade = grade;
        this.isCalculated = isCalculated;
    }
}
