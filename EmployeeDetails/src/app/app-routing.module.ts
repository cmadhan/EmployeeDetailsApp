import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeDashboardComponent } from './EmployeeDashboard/employee-dashboard.component';
import { AddEmployeeComponent } from './EmployeeDashboard/AddEmployee/add-employee.component';
import { EditEmployeeComponent } from './EmployeeDashboard/EditEmployee/edit-employee.component';
const routes: Routes = [

  // Site Layout Routes
  {
    path: 'Employees', component: EmployeeDashboardComponent, children: [
      { path: "AddNew", component: AddEmployeeComponent },
      { path: "Edit/:employeeId", component: EditEmployeeComponent },
    ],
  },
  { path: '',   redirectTo: '/Employees', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
