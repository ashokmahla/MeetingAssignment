import { Input, Component, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../services/authentication.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {

  constructor(private router:Router,private authenticationService:AuthenticationService){

  }
  error:any;
  form: FormGroup = new FormGroup({
    username: new FormControl('',Validators.required),
    password: new FormControl('',Validators.required),
  });

  submit() {
  
    if (this.form.invalid) {
        return;
    }
    let userName = this.form.get('username').value;
    let userPassword = this.form.get('password').value;
    this.authenticationService.login(userName,userPassword)
    .pipe(first())
    .subscribe(
        data => {
          this.router.navigate(['meetings']);
        },
        error => {
          this.error = error;
        });
  
     
  }
 
}
