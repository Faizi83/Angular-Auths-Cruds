import { Component } from '@angular/core';
import { FormGroup,FormBuilder,Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router'; 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm!: FormGroup ;

  constructor(private fb: FormBuilder, private userservice: UserService, private router: Router ){
    this.loginForm = fb.group({
      Email:['',Validators.required],
      Password:['',Validators.required]
    })
  }


  onSubmit(){
    if(this.loginForm.valid){
      this.userservice.loginuser(this.loginForm.value).subscribe({
       next:(response) => {
         console.log("User Login Successfuly", response)
         this.router.navigate(['/home']);
         if (response.token) {
          localStorage.setItem('userToken', response.token); // Store the token
          console.log("Token stored in local storage:", response.token);
        }
       },
       error:(error) => {
        console.log("Error While Login", error)
       }
      
      })
    }
  }
}
