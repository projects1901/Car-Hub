import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICarModel } from '../models/icar-model';

@Injectable({
  providedIn: 'root'
})
export class CarModelService {

  private apiUrl = 'https://localhost:7004/api/Car'; // Adjust URL accordingly

  constructor(private http: HttpClient) { }

  addCarModel(carModel: ICarModel): Observable<any> {
    return this.http.post(this.apiUrl, carModel);
  }

  login(username: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, { username, password });
  }

  register(fullName: string, username: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, { fullName, username, password });
  }

  getAllCarModel(): Observable<ICarModel[]> {
    return this.http.get<ICarModel[]>(this.apiUrl);
  }
}
