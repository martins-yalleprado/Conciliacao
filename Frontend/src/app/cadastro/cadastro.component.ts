import { Component, OnInit, ElementRef } from '@angular/core';

declare var jQuery: any;

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  constructor(private el:ElementRef){}

  locations: any;


  ngOnInit() {

    jQuery(this.el.nativeElement).find('.modal').modal({
    });

    jQuery(this.el.nativeElement).find('ul.tabs').tabs({
    });

    this.locations = {
      'apple': null,
      'google': null,
      'microsoft': null
     };

  }
}
