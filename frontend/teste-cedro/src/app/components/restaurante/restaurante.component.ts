import { AlertComponent } from '../alert-component/alert.component';
import { RestauranteService } from './restaurante.service';
import { Component, OnInit } from '@angular/core';
import { Restaurante } from '../../types/restaurante';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { Observable } from 'rxjs';
import { filter } from 'rxjs/operators'
import { AddDialogComponent } from '../../dialogs/add/add.dialog.component';
import * as moment from 'moment';

@Component({
  selector: 'restaurante',
  templateUrl: './restaurante.component.html',
  styleUrls: ['./restaurante.component.css']
})

export class RestauranteComponent implements OnInit {

  dataSource = new MatTableDataSource([]);
  displayedColumns: string[] = ['id', 'nome', 'dataCriacao', 'dataAtualizacao', 'actions'];
  constructor(private serice: RestauranteService, private dlg: MatDialog, public dialog: MatDialog) { }


  ngOnInit() {
    this.serice.get().subscribe((result) => {
      console.warn(result)
      this.dataSource = new MatTableDataSource(result);
    });
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  addNew() {
    const dialogRef = this.dialog.open(AddDialogComponent, {
      data: {} as Restaurante
    });

    dialogRef.afterClosed().subscribe((item: Restaurante) => {
      if (item) {

        this.serice.create(item).subscribe((response: any) => {
          
          if (response.ok){
            this.dataSource = new MatTableDataSource(response.data);
          } else {
            console.error(response.errors)
          }
        });
        // this.refreshTable();
      }
    });
  }
  edit(index: number, item: Restaurante) {
    const dialogRef = this.dialog.open(AddDialogComponent, {
      data: Object.assign({}, item)
    });

    dialogRef.afterClosed().subscribe((item: Restaurante) => {
      
      if (item) {

        this.serice.update(item).subscribe((response: any) => {
          if (response.ok){
            this.dataSource =new MatTableDataSource(response.data);
          } else {
            console.error(response.errors)
          }
        });
        // this.refreshTable();
      }
    });
  }
  formatDate(date: string): string {
    if (date)
      return moment(date).format('DD/MM/YYYY HH:mm:ss');
  }
  delete(evt: Event, id: number): void {
    evt.preventDefault();
    evt.stopPropagation();
    this.dlg.open<AlertComponent>(AlertComponent, { height: '200px', width: '300px', data: 'Tem certeza que deseja Apagar?' })
      .afterClosed().pipe(
        filter((x: string) => x === 'yes')
      ).subscribe((): void => {
        this.serice.delete(id).subscribe(((response: any) => {
          if (response.ok){
            this.dataSource = new MatTableDataSource(response.data);
          } else {
            console.error(response.errors)
          }
        }))
      });
  }

}
