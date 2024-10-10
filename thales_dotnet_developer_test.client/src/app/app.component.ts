import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from "@angular/forms";

interface EmployeeModel {
  id: number
  firstName: string
  lastName: string
  email: string
  age: number
  annualSalary: number
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public employees: EmployeeModel[] = [];
  idEmployee = new FormControl("");
  constructor (private http: HttpClient){}

  title = 'Angular Bootstrap with MVC';
  visible: boolean = false;
  isData: boolean = true;
  url = "";

  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
  
  visibility() {
    this.visible = true;
  }

  getEmployees() {
    
    if(this.idEmployee.getRawValue() == ''){
      this.url = 'https://localhost:44356/api/Employee/GetAll'
    }
    else{
      this.url = 'https://localhost:44356/api/Employee/GetById?idEmployee=' + this.idEmployee.getRawValue()
    }

    this.http.get<EmployeeModel[]>(this.url).subscribe(
      (result) => {        
        this.employees = result;
        if(this.employees.length > 0){
          this.visibility();
          this.isData = true;
        }
        else{
          this.isData = false;
        }
      },
      (error) => {
        this.isData = false;
        console.error(error);
      }
    );
  }
}
