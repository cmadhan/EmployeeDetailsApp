import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../Configuration/AppConfig';
import { Observable } from 'rxjs';
import { Employee } from '../Model/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private applicationConfiguration: AppConfig = new AppConfig();
  constructor(private httpClient: HttpClient) { }

  GetAllEmployees(): Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.applicationConfiguration.getAllEmployeesURL);
  }

  DeleteEmployee(employeeId: number): Observable<object> {
    return this.httpClient.delete(this.applicationConfiguration.employeeUpdateURL+'?employeeId='+employeeId);
  }

  AddEmployee(employeeToAdd: Employee): Observable<object> {
    return this.httpClient.post(this.applicationConfiguration.employeeUpdateURL, employeeToAdd);
  }

  UpdateEmployee(employeeToUpdate: Employee) : Observable<object> {
    return this.httpClient.put(this.applicationConfiguration.employeeUpdateURL, employeeToUpdate);
  }

  GetEmployeeById(employeeId: string | null) : Observable<Employee> {
      return this.httpClient.get<Employee>(this.applicationConfiguration.getEmployeeURL+ '?employeeId=' + employeeId);
  }
}
