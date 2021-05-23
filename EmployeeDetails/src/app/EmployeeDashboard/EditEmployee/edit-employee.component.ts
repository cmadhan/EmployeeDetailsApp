import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from 'src/app/EmployeeService/employee-service.service';
import { Employee } from 'src/app/Model/Employee';

@Component({
  selector: 'app-edit-employee',
  templateUrl: '../../Shared/employee-form.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  employeeForm!: FormGroup;
  employee!: Employee;
  loading: boolean = false;
    constructor(private router : Router, private route: ActivatedRoute, private employeeService: EmployeeService, private editEmployeeFormBuilder: FormBuilder) { 
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit(): void {
    this.loading = true;
    const employeeId = this.route.snapshot.paramMap.get('employeeId')
    this.employeeForm = this.editEmployeeFormBuilder.group({
      FullName: ['', Validators.required],
      Address: ['', Validators.required],
      PhoneNumber: ['', Validators.required],
      Position: ['', Validators.required]
    });
    this.employeeService.GetEmployeeById(employeeId).subscribe(res => {
      this.employeeForm.setValue({
        FullName: res.FullName,
        Address: res.Address,
        PhoneNumber: res.PhoneNumber,
        Position: res.Position
      });
      this.loading = false;
    }, error => {
      console.log(error);
      this.loading = true;
    });    
  }

  saveEmployee() {
    this.loading = true;
    const employeeToAdd = { ...this.employee, ...this.employeeForm.value };
    this.employeeService.UpdateEmployee(employeeToAdd).subscribe(res => {
      this.router.navigate(['/Employees']);
      console.log(res)
      this.loading = false;
    }, error => {
      console.log(error);
      this.loading = true;
    });
  }

}
