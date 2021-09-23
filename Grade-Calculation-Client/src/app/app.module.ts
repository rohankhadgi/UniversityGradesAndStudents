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
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule, Routes } from '@angular/router';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { GridModule } from '@progress/kendo-angular-grid';
import { MatCardModule } from '@angular/material/card';


const appRoutes: Routes = [
  { path: 'courses', component: CoursesComponent },
  { path: 'students', component: StudentsComponent },
];

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
    NgbModule,
    MatTabsModule,
    MatCardModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true }
    ),
    ToastrModule.forRoot(),
    NgMultiSelectDropDownModule.forRoot(),
    InputsModule,
    GridModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
