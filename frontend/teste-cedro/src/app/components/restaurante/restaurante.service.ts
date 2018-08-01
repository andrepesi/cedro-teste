import { Restaurante } from '../../types/restaurante';
import { BaseService } from '../services/base.service';
import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RestauranteService extends BaseService<Restaurante> {
 
  listPratos: Restaurante[];
  constructor(client: HttpClient) {
    super(client, 'restaurante')
  }
}