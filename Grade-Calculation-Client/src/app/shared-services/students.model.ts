import { StudentCourse } from "./studentcourses.model";

export class Student {
    studentID: number=0;
    studentName: string='';
    studentNumber: string='';
    cgpa: number=0;
    studentCourses: StudentCourse[]=[];
}
