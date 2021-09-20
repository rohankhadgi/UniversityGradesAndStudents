import { StudentCourse } from "./studentcourses.model";

export class Student {
    studentID: number=0;
    studentName: string='';
    studentNumber: string='';
    cGPA: number=0;
    studentCourses: StudentCourse[]=[];
}
