import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { EventEmitter} from '@angular/core';
import { User } from '../user'

import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent implements OnInit {

  user: User = new User();
  constructor(private service: AuthService, private router: Router) { }

  ngOnInit() {
  }

  login(user) {
    const self = this;
    user = 'username=' + user.username + '&password=' + user.password + '&grant_type=password';

      this.service.login(user).then(function(data) {
        self.service.setToken(JSON.parse(data['_body'])['access_token']);
        self.router.navigate(['/home']);
      });
  }

  logout() {
    this.service.removeToken();
  }


}
