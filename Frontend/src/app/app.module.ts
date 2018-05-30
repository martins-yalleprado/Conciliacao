import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { FlashMessagesModule } from 'angular2-flash-messages';

import { MaterializeModule } from "angular2-materialize";
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { MomentModule } from 'angular2-moment';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { ChargeManagementComponent } from './chargeManagement/chargeManagement.component';

import { Routing } from './app.routes';
import { JsonDataService } from './json-data.service';
import { AuthRequestOptions } from './auth-request';
import { AuthErrorHandler } from './auth-error-handler';
import { AuthService } from './auth.service';
import { AuthGuard } from './auth.guard';
import { NotFoundComponent } from './not-found/not-found.component';
import { PendingConciliationComponent } from './pendingConciliation/pendingConciliation.component';
import { HomeComponent } from './home/home.component';

import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import ptBr from '@angular/common/locales/pt';
registerLocaleData(ptBr)


import { PendingConciliationService } from './pendingConciliation/pending-conciliation.service';
import { ChargeManagementService } from './chargeManagement/charge-management.service';
import { AgingPeriodService } from './agingPeriod/aging-period.service';
import { AgingPeriodComponent } from './agingPeriod/agingPeriod.component';
import { ConfiguracaoEmpresaComponent } from './configuracao-empresa/configuracao-empresa.component';
import { SelecionaUnidadeComponent } from './seleciona-unidade/seleciona-unidade.component';
import { TiposMovimentacoesComponent } from './tipos-movimentacoes/tipos-movimentacoes.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CadastroComponent,
    ChargeManagementComponent,
    NotFoundComponent,
    PendingConciliationComponent,
    HomeComponent,
    AgingPeriodComponent,
    ConfiguracaoEmpresaComponent,
    SelecionaUnidadeComponent,
    TiposMovimentacoesComponent
  ],
  imports: [
    BrowserModule,
    MaterializeModule,
    Routing,
    HttpModule,
    FormsModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    FlashMessagesModule.forRoot(),
    // MomentModule
  ],
  providers: [
    {
      provide: RequestOptions,
      useClass: AuthRequestOptions
    },
    {
      provide: LOCALE_ID,
      useValue: 'pt-BR'
    },
    JsonDataService,
    PendingConciliationService,
    ChargeManagementService,
    AgingPeriodService,
    AuthRequestOptions,
    AuthErrorHandler,
    AuthService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
