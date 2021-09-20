import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { CoursesComponent } from './courses/courses.component';
import { CourseFormComponent } from './courses/course-form/course-form.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { StudentsComponent } from './students/students.component';
import { StudentFormComponent } from './students/student-form/student-form.component'

@NgModule({
  declarations: [
    AppComponent,
    CoursesComponent,
    CourseFormComponent,
    StudentsComponent,
    StudentFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
