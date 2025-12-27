import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PickSlipInquiryService {

  private baseUrl = 'https://localhost:7261/api/PickSlipInquiry';

  constructor(private http: HttpClient) { }

  getInquiry(params: any): Observable<any> {
    let queryParams = new HttpParams()
      .set('page', params.page)
      .set('pageSize', params.pageSize);

    if (params.type) queryParams = queryParams.set('type', params.type);
    if (params.number) queryParams = queryParams.set('number', params.number);
    if (params.date) queryParams = queryParams.set('date', params.date);
    if (params.search) queryParams = queryParams.set('search', params.search);

    return this.http.get<any>(this.baseUrl, { params: queryParams });
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getById(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/${id}`);
  }

  // 🔥 NEW UPDATE METHOD
  update(item: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/${item.id}`, item);
  }
}
