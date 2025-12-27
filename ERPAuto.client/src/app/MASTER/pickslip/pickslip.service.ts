import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface PickSlip {
  id?: number;
  fran: string;
  brch: string;
  whse: string;
  pickslipdate: string;
  picksliptype: string;
  pickslipno: number;
  pickslipsrl: number;
  pickslipstatus: string;
  store: string;
  make: string;
  part: number;
  qty: number;
  suppliedqty: number;
  reftype: string;
  refno: string;
  refsrl: number;
  repairorderno: string;
  picktype: string;
  pickno: number;
  pickerempid: string;
  salesmanid: string;
  remarks: string;
  createdt: string;
  createtm: string;
  createby: string;
  createremarks: string;
  updatedt: string;
  updatetm: string;
  updateby: string;
  updatemarks: string;
}

@Injectable({
  providedIn: 'root'
})
export class PickslipService {
  private apiUrl = 'https://localhost:7261/api/PickSlips'; // ✅ Your API endpoint

  constructor(private http: HttpClient) { }

  getPickSlips(): Observable<PickSlip[]> {
    return this.http.get<PickSlip[]>(this.apiUrl);
  }

  createPickSlip(pickSlip: PickSlip): Observable<PickSlip> {
    return this.http.post<PickSlip>(this.apiUrl, pickSlip);
  }

  updatePickSlip(id: number, pickSlip: PickSlip): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, pickSlip);
  }

  deletePickSlip(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
