// added this service page
// added by - Vaishnavi
// added date - 08-12-2025

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  // 🔹 Base API URL
  private baseUrl = 'https://localhost:7231/api/v1';

  constructor(private http: HttpClient) { }

  // ===================== MASTER =====================

  // ----------- MAKE LIST -----------
  getMakeList(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/master/Makes/GetMake`);
  }


  // ----------- GET ALL PARTS -----------
  getAllParts(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/master/Parts/Getparts`);
  }

  // ----------- ADD PART -----------
  addPart(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/master/Parts/add-part`, data);
  }

  // ----------- CUSTOMER MASTER -----------

  getAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.baseUrl}/master/customers`);
  }

  getCustomerByCode(customerCode: string): Observable<Customer> {
    return this.http.get<Customer>(
      `${this.baseUrl}/master/customers/${customerCode}`
    );
  }

  addCustomer(customer: Customer): Observable<any> {
    return this.http.post(
      `${this.baseUrl}/master/customers`,
      customer
    );
  }

  updateCustomer(customerCode: string, customer: Customer): Observable<any> {
    if (!customer.updateBy) {
      customer.updateBy = 'api';
    }
    if (!customer.updateRemarks) {
      customer.updateRemarks = '';
    }

    return this.http.put(
      `${this.baseUrl}/master/customers/${customerCode}`,
      customer,
      { observe: 'response' }
    );
  }

  deleteCustomer(customerCode: string): Observable<any> {
    return this.http.delete(
      `${this.baseUrl}/master/customers/${customerCode}`,
      { observe: 'response' }
    );
  }

  // ===================== FINANCE =====================

  // ----------- DROPDOWN PARAMS -----------
  getParams(fran: string, type: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.baseUrl}/finance/params/load/${fran}/${type}`
    );
  }

  // ----------- ACCOUNTS RECEIVABLE ----------
  getReceivables(fran: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.baseUrl}/orders/sales/receivable`,
      { params: { fran } }
    );
  }

  // ----------- ACCOUNTS PAYABLE ----------
  getPayables(fran: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.baseUrl}/orders/sales/payable`,
      { params: { fran } }
    );
  }

  // ----------- INVOICE AP ----------
  getInvoiceAP(fran: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.baseUrl}/SALEHDRs/InvoiceAP/${fran}`
    );
  }

  // ----------- INVOICE AR ----------
  getInvoiceAR(fran: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.baseUrl}/SALEHDRs/InvoiceAR/${fran}`
    );
  }

  // ----------- PAYMENT / JOURNAL ENTRY ----------
  addJournalEntry(data: {
    customer: string;
    saleNo: string;
    billAmount: number;
    paymentMethod: string;
    cardNumber?: string;
    remarks?: string;
  }): Observable<any> {
    return this.http.post(
      `${this.baseUrl}/finance/JournalEntries/InsertJournal`,
      data
    );
  }

  // ===================== EXPENSE =====================

  // ----------- ADD EXPENSE ----------
  addExpenseEntry(data: any): Observable<any> {
    return this.http.post(
      `${this.baseUrl}/EXPENSE/Add`,
      data
    );
  }

  // ----------- GET ALL EXPENSES ----------
  getAllExpenses(): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.baseUrl}/EXPENSE/GetAll`
    );
  }

  // ===================== SALES =====================

  // ----------- SAVE SALE INVOICE ----------
  saveSaleInvoice(data: any): Observable<any> {
    return this.http.post(
      `${this.baseUrl}/SaveSaleInvoice`,
      data
    );
  }
}

// ===================== MODELS =====================
export interface Customer {
  customerCode: string;
  id?: number;
  name: string;
  nameAr: string;
  phone: string;
  email: string;
  address: string;
  vatNo: string;
  createdDate?: string;
  updateDate?: string;
  updateBy?: string;
  updateRemarks?: string;
}
