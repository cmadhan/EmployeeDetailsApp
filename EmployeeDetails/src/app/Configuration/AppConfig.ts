export class AppConfig {
    private baseURL: string = 'http://localhost:53192'
    public getAllEmployeesURL: string = this.baseURL + '/api/Employees/GetAllEmployees';
    public getEmployeeURL: string = this.baseURL + '/api/Employees/GetEmployee';
    public employeeUpdateURL: string = this.baseURL + '/api/Employees/Employee';
}