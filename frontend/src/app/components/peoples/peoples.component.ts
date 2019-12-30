import { Component, OnInit } from '@angular/core';
import { ConfigService } from 'src/app/config.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-peoples',
  templateUrl: './peoples.component.html',
  styleUrls: ['./peoples.component.css']
})
export class PeoplesComponent implements OnInit {
  constructor(private myService : ConfigService, private router: Router) { }

  resp: {};
  error = [];
  registers: {};
  statusRequest = false;

  ngOnInit() {
    this.myService.getAllOfLIST().subscribe(data => {
      this.registers = data;
      this.statusRequest = true;
      console.log(this.registers + " " + this.statusRequest);
    })
  }

  deleteRegister(id){
    this.myService.deleteRegisterService(id).subscribe(data => {
      this.resp = data;
      switch (JSON.stringify(this.resp)) {
        case JSON.stringify("SUCCESS"):
          this.myService.getAllOfLIST().subscribe(data => {
            this.registers = data;
          });
          this.error.push("Ok, register was deleted");
          break;
      
          case JSON.stringify("FAIL"):
          this.error.push("Try again");
          break;

          case JSON.stringify("ERROR"):
          this.error.push("Error");
          break;
      }
    })
  }


  sendIdByUrl(id){
    this.router.navigate(['/update', id]);
  }


}

