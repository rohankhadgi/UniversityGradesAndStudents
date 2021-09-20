import { Course } from "./courses.model";
import { Student } from "./students.model";

export class StudentCourse {
    studentID: number=0;
    courseID: number=0;
    grade: string='';
    isCalculated: boolean=false;
    hasPassed: boolean=false;
    student: Student;
    course: Course;
}
