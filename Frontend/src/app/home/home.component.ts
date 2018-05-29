import { Component, OnInit, ElementRef } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { User } from '../models/User';

declare var jQuery: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currentUser: User;
  constructor(private el: ElementRef, private service: AuthService, private router: Router) { 
    this.currentUser = JSON.parse(localStorage.getItem('user'));
  }

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

  atualizaMenu(valor: string){
    this.currentUser.menu = valor;
  }

  logout() {
    this.service.removeToken();
    this.router.navigate(['/login']);
  }
}
