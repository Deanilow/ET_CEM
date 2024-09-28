import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { LibeyUser } from 'src/app/entities/libeyuser';
import {
  LibeyUsersApiResponse,
  LibeyUserApiResponse,
  DeleteApiResponse,
} from 'src/app/entities/apiRespose';

@Injectable({
  providedIn: 'root',
})
export class LibeyUserService {
  constructor(private http: HttpClient) {}

  Find(documentNumber: string): Observable<LibeyUserApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
    return this.http.get<LibeyUserApiResponse>(uri);
  }

  GetAll(): Observable<LibeyUsersApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
    return this.http.get<LibeyUsersApiResponse>(uri);
  }

  GetAllFilter(textFilter: string): Observable<LibeyUsersApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/Filter?textFilter=${textFilter}`;
    return this.http.get<LibeyUsersApiResponse>(uri);
  }

  Create(user: LibeyUser): Observable<LibeyUserApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
    return this.http.post<LibeyUserApiResponse>(uri, user);
  }

  Update(user: LibeyUser): Observable<LibeyUserApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
    return this.http.put<LibeyUserApiResponse>(uri, user);
  }

  Delete(documentNumber: string): Observable<DeleteApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser?documentNumber=${documentNumber}`;
    return this.http.delete<DeleteApiResponse>(uri);
  }
}
