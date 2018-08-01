import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class BaseService<T> {
    apiUrl: string;
    constructor(private http: HttpClient, endpoint: string){
        this.apiUrl=  `http://localhost:5000/api/${endpoint}`;
    }
    get(): Observable<T[]> {
        return this.http.get<T[]>(this.apiUrl);
    }
    getById(id: number):Observable<T>{
        return this.http.get<T>(this.apiUrl+ `/${id}`);

    }
    create(obj: T){
        return this.http.post(this.apiUrl,obj);
    }
    update(obj: T){
        return this.http.put(this.apiUrl,obj);
    }
    delete(id: number){
        return this.http.delete(this.apiUrl+ `/${id}`);        
    }
}