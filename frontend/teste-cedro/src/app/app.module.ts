import { FilterPipe } from './pipes/filter.pipe';
import { PratoDialogComponent } from './dialogs/prato-dialog/prato.dialog.component';
import { AddDialogComponent } from './dialogs/add/add.dialog.component';
import { RestauranteService } from './components/restaurante/restaurante.service';
import { HttpClientModule } from '@angular/common/http';
import { BaseService } from './components/services/base.service';
import { AppRoutingModule } from './app/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatInputModule, MatFormFieldModule, MatToolbarModule, MatTableModule, MatIconModule, MatCardModule, MatDialogModule, MatPaginatorModule, MatSelectModule } from '@angular/material';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { RestauranteComponent } from './components/restaurante/restaurante.component';
import { PratosComponent } from './components/pratos/pratos.component';
import { PratoService } from './components/pratos/prato.service';
import { RestauranteEditComponent } from './components/restaurante-edit/restaurante-edit.component';
import { AlertComponent } from './components/alert-component/alert.component';
import { CurrencyMaskModule } from "ng2-currency-mask";


@NgModule({
  declarations: [
    AppComponent,
    AddDialogComponent,
    RestauranteComponent,
    PratosComponent,
    RestauranteEditComponent,
    AlertComponent,
    PratoDialogComponent,
    FilterPipe
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    MatToolbarModule,
    MatTableModule,
    MatIconModule,
    MatCardModule,
    AppRoutingModule,
    MatDialogModule,
    MatFormFieldModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatInputModule,
    MatPaginatorModule,
    MatSelectModule,
    CurrencyMaskModule,
    MatButtonModule,
    FormsModule
  ],
  providers: [PratoService, BaseService, RestauranteService],
  entryComponents: [
    AlertComponent, AddDialogComponent,PratoDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
