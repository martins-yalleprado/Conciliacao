import { Component, OnInit, ElementRef } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
import {FlashMessage} from 'angular-flash-message';

declare var jQuery: any;


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private el: ElementRef, private service: AuthService, private router: Router) { }

  ngOnInit() {

    jQuery(this.el.nativeElement).find('.button-collapse').sideNav({
      menuWidth: 300,
      closeOnClick: true,
      edge: 'left',
      draggable: true,
      isOpen: false,
    });

    jQuery(this.el.nativeElement).find('.collapsible').collapsible({
    });

    jQuery(this.el.nativeElement).find('.collapsible.expandable').collapsible({
      accordion: false
    });

  }

    logout() {
      this.service.removeToken();
      this.router.navigate(['/login']);
  }

}
