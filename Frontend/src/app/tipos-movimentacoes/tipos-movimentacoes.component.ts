import { Component, OnInit, ElementRef } from '@angular/core';

declare var jQuery: any;

@Component({
  selector: 'app-tipos-movimentacoes',
  templateUrl: './tipos-movimentacoes.component.html',
  styleUrls: ['./tipos-movimentacoes.component.css']
})
export class TiposMovimentacoesComponent implements OnInit {

  constructor(private el: ElementRef) { }

  ngOnInit() {

    jQuery(this.el.nativeElement).find('.collapsible').collapsible({
    });

  }

}
