import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../EmployeeService/employee-service.service';
import { Employee } from '../Model/Employee';

@Component({
  selector: 'app-employee-dashboard',
  templateUrl: './employee-dashboard.component.html',
  styleUrls: ['./employee-dashboard.component.css']
})
export class EmployeeDashboardComponent implements OnInit {

  loading: boolean = false;
  allEmployees: Employee[] = [];
  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.loading = true;
    this.loadEmployees()
  }

  deleteEmployee(employeeToDelete: number) {
    this.loading = true;
    this.employeeService.DeleteEmployee(employeeToDelete).subscribe(res => {
      this.loadEmployees();
    }, error => {
      console.log(error);
      this.loading = true;
    });
  }

  private loadEmployees() {
    this.employeeService.GetAllEmployees().subscribe(res => {
      this.allEmployees = res.sort((e1, e2) => {
        if (e1.FullName > e2.FullName) {
          return 1;
        } else if (e1.FullName < e2.FullName) {
          return -1;
        }
        return 0;
      })
      console.log(this.allEmployees)
      this.loading = false;
    });
  }

}
