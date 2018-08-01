import { MatDialog, MatTableDataSource } from '@angular/material';
import { PratoDialogComponent } from './../../dialogs/prato-dialog/prato.dialog.component';
import { Prato } from '../../types/pratos';
import { PratoService } from './prato.service';
import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { AlertComponent } from '../alert-component/alert.component';
import { filter } from 'rxjs/operators'
@Component({
  selector: 'app-pratos',
  templateUrl: './pratos.component.html',
  styleUrls: ['./pratos.component.css']
})
export class PratosComponent implements OnInit {

  dataSource = new MatTableDataSource([]);
  displayedColumns: string[] = ['id', 'nome', 'preco', 'nomeRestaurante', 'dataCriacao', 'dataAtualizacao', 'actions'];
  constructor(private serice: PratoService,private dlg: MatDialog, public dialog: MatDialog) { }

  ngOnInit(): void {

    this.serice.get().subscribe((result) => {
      console.warn(result)
      this.dataSource =new MatTableDataSource(result);
    });
  }
  addNew() {
    const dialogRef = this.dialog.open(PratoDialogComponent, 
      { height: '350px', width: '600px',  data: {} as Prato }
    );

    dialogRef.afterClosed().subscribe((item: Prato) => {
      
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
  edit(index: number, item: Prato) {
    const dialogRef = this.dialog.open(PratoDialogComponent, {
      data: Object.assign({}, item)
    });

    dialogRef.afterClosed().subscribe((item: Prato) => {
      if (item) {

        this.serice.update(item).subscribe((response: any) => {
         
          if (response.ok){
            this.dataSource = new MatTableDataSource(response.data);
          } else {
            console.error(response.errors)
          }
        });
      }
    });
  }
  formatDate(date: string): string {
    if (date)
      return moment(date).format('DD/MM/YYYY HH:mm:ss');
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
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
