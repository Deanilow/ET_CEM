import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { DocumentTypesApiResponse, ProvincesApiResponse, RegionsApiResponse, UbigeosApiResponse } from 'src/app/entities/apiRespose';

@Injectable({
  providedIn: 'root',
})
export class UtilService {
  constructor(private http: HttpClient) {}

  FindProvince(regionCode: string): Observable<ProvincesApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}Province/${regionCode}`;
    return this.http.get<ProvincesApiResponse>(uri);
  }

  FindUbigeo(provinceCode: string): Observable<UbigeosApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}Ubigeo/${provinceCode}`;
    return this.http.get<UbigeosApiResponse>(uri);
  }

  GetAllRegion(): Observable<RegionsApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}Region`;
    return this.http.get<RegionsApiResponse>(uri);
  }

  GetAllDocumentsType(): Observable<DocumentTypesApiResponse> {
    const uri = `${environment.pathLibeyTechnicalTest}DocumentType`;
    return this.http.get<DocumentTypesApiResponse>(uri);
  }

}
