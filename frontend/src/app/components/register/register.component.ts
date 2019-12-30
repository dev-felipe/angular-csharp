import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ConfigService } from 'src/app/config.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  error = [];

  profileForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    phone: new FormControl(''),
    job: new FormControl('')
  });

  constructor(private myService : ConfigService, private router: Router) { }
  resp = {}
  ngOnInit() {
  }

  insertNew(){
    this.myService.insertNewService(this.profileForm.value)
    .subscribe(data => {
      this.resp = data;
      switch (JSON.stringify(this.resp)) {
        
        case JSON.stringify("SUCCESS"):
          console.log(data + " / / " + this.resp);
          this.error.push("Ok, its fine!");
          setTimeout(() => this.router.navigate(['/peoples']), 1000);
          break;

          case JSON.stringify("EMAILEXIST"):
            this.error.push("This email is on use, try with another!");
            break;
      
          case JSON.stringify("FAIL"):
          this.error.push("Try again");
          break;

          case JSON.stringify("ERROR"):
          this.error.push("Error");
          break;
      }
    });
    console.log(this.error);
  }
}
