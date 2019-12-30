import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ConfigService {
  constructor(private http: HttpClient) { }

  getAllOfLIST() {
    return this.http.get('https://angular-aspnetcore.azurewebsites.net/api/user');
  };

  insertNewService(obj){
    return this.http.post('https://angular-aspnetcore.azurewebsites.net/api/user/', {
      name: obj.name,
      email: obj.email,
      phone: obj.phone,
      job: obj.job
    }, {responseType:'text' as 'json'});
  }

  deleteRegisterService(id){
    return this.http.delete('https://angular-aspnetcore.azurewebsites.net/api/user/' + id, {responseType:'text' as 'json'});
  }

  getByIdService(id){
    return this.http.get('https://angular-aspnetcore.azurewebsites.net/api/user/' + id);
  }

  updateRegisterService(id, obj){
    return this.http.put('https://angular-aspnetcore.azurewebsites.net/api/user/' + id, {
      id: obj.id,
      name: obj.name,
      email: obj.email,
      phone: obj.phone,
      job: obj.job
    }, {responseType:'text' as 'json'});
  }

}

