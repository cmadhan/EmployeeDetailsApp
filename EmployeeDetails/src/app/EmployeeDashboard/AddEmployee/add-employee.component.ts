import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/EmployeeService/employee-service.service';
import { Employee } from 'src/app/Model/Employee';

@Component({
  selector: 'app-add-employee',
  templateUrl: '../../Shared/employee-form.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

 employeeForm!: FormGroup;
  employee!: Employee;
  constructor(private addEmployeeFormBuilder: FormBuilder, private router: Router, private employeeService: EmployeeService) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit(): void {
    this.employeeForm = this.addEmployeeFormBuilder.group({
      FullName: ['', Validators.required],
      Address: ['', Validators.required],
      PhoneNumber: ['', Validators.required],
      Position: ['', Validators.required]
    });
  }

  saveEmployee(): void {
    const employeeToAdd = { ...this.employee, ...this.employeeForm.value };
    this.employeeService.AddEmployee(employeeToAdd).subscribe(res => {
      this.router.navigate(['/Employees']);
      console.log(res)
    });
  }

}
