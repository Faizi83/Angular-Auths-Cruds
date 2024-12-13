import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm!: FormGroup;



  constructor(private fb: FormBuilder, private userservices: UserService) {
    this.registerForm = fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Phone: ['', Validators.required],
      City: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', Validators.required]
    })
  }

  onSubmit() {
    if (this.registerForm.valid) {
      this.userservices.registeruser(this.registerForm.value).subscribe({
        next:(response) => {
        alert("User Registered Successfuly")
       this.registerForm.reset()
      },
        error: (error) => {
          console.error('Validation Error:', error);
          alert("Eroor While Registring")
        },
        complete: () => {
          console.log("User Added Completely")
        }


    })

  }

}

}
