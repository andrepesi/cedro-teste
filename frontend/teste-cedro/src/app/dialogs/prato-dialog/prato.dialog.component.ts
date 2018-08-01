import { Restaurante } from './../../types/restaurante';
import { Prato } from './../../types/pratos';
import { RestauranteService } from '../../components/restaurante/restaurante.service';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material';
import { Component, Inject, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-baza.dialog',
  templateUrl: '../../dialogs/prato-dialog/prato.dialog.html',
  styleUrls: ['../../dialogs/prato-dialog/prato.dialog.css']
})
export class PratoDialogComponent implements OnInit{

  restaurantes: Restaurante[] = [];

  constructor(public dialogRef: MatDialogRef<PratoDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Prato, public rstService: RestauranteService) { }
  
  formControl = new FormControl('', [
    Validators.required
    // Validators.email,
  ]);
  ngOnInit(){
    this.rstService.get().subscribe((result) => {
      console.warn(result)
      this.restaurantes = result;
    });
  }
  getErrorMessage() {
    return this.formControl.hasError('required') ? 'Campo obrigátorio' :
        '';
  }

  submit() {
    // emppty stuff
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  stopEdit(): void {
    this.dialogRef.close(this.data);
  }
}
