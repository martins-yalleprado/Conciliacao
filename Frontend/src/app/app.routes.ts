// Imports
// Deprecated import
// import { provideRouter, RouterConfig } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { ChargeManagementComponent } from './chargeManagement/chargeManagement.component';
import { PendingConciliationComponent } from './pendingConciliation/pendingConciliation.component';
import { AgingPeriodComponent } from './agingPeriod/agingPeriod.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth.guard';
import { SelecionaUnidadeComponent } from './seleciona-unidade/seleciona-unidade.component';
import { ConfiguracaoEmpresaComponent } from './configuracao-empresa/configuracao-empresa.component';
import { TiposMovimentacoesComponent } from './tipos-movimentacoes/tipos-movimentacoes.component';


// Route Configuration
export const routes: Routes = [
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full',
    canActivate: [AuthGuard],
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],

      children: [
      {
        path: 'chargeManagement',
        component: ChargeManagementComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'pendingConciliation',
        component: PendingConciliationComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'agingPeriod',
        component: AgingPeriodComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'selecionaUnidade',
        component: SelecionaUnidadeComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'configuracaoEmpresa',
        component: ConfiguracaoEmpresaComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'tiposMovimentacoes',
        component: TiposMovimentacoesComponent,
        canActivate: [AuthGuard]
      },
      // {
      //   path: '**',
      //   component: NotFoundComponent,
      //   canActivate: [AuthGuard]
      // },
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  },

];

// Deprecated provide
// export const APP_ROUTER_PROVIDERS = [
//   provideRouter(routes)
// ];

export const Routing: ModuleWithProviders = RouterModule.forRoot(routes);
