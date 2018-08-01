import { Prato } from '../../types/pratos';
import { BaseService } from '../services/base.service';
import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PratoService extends BaseService<Prato> {
 
  listPratos: Prato[];
  constructor(client: HttpClient) {
    super(client, 'prato')
  }
}
