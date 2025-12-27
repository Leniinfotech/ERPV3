import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Fran {
  franCode: string;
  name: string;
  nameAr: string;
}

@Injectable({
  providedIn: 'root'
})
export class FranService {
  private apiUrl = 'https://localhost:7261/api/FRANs'; // ✅ Adjust if needed

  constructor(private http: HttpClient) { }

  // 🔹 Get all FRANs
  getAll(): Observable<Fran[]> {
    return this.http.get<Fran[]>(this.apiUrl);
  }

  // 🔹 Create FRAN
  create(fran: Fran): Observable<Fran> {
    return this.http.post<Fran>(this.apiUrl, fran);
  }

  // 🔹 Update FRAN (using FranCode as key)
  update(franCode: string, fran: Fran): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${franCode}`, fran);
  }

  // 🔹 Delete FRAN (using FranCode as key)
  delete(franCode: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${franCode}`);
  }
}
