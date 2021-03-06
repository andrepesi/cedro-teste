import { PratosComponent } from './components/pratos/pratos.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RestauranteComponent } from './components/restaurante/restaurante.component';

const routes: Routes = [
  {
    path: '',
    component : RestauranteComponent
  },
  {
    path: 'restaurante',
    component : RestauranteComponent
  },
  {
    path: 'prato',
    component : PratosComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
