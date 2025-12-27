import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import * as XLSX from 'xlsx';
import { ApiService } from '../../services/api.service'; // ✅ UPDATED

@Component({
  selector: 'app-saleinvoice',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './sale-invoice.component.html'
})
export class SaleInvoiceComponent {

  invoiceForm!: FormGroup;
  invoiceList: any[] = [];

  constructor(
    private fb: FormBuilder,
    private apiService: ApiService // ✅ UPDATED
  ) {
    this.invoiceForm = this.fb.group({
      invoiceNo: [''],
      customerName: [''],
      product: [''],
      make: [''],
      quantity: [''],
      unitPrice: [''],
      total: [{ value: 0, disabled: true }]
    });

    this.invoiceForm.get('quantity')?.valueChanges.subscribe(() => this.calculateTotal());
    this.invoiceForm.get('unitPrice')?.valueChanges.subscribe(() => this.calculateTotal());
  }

  calculateTotal() {
    const qty = this.invoiceForm.get('quantity')?.value || 0;
    const price = this.invoiceForm.get('unitPrice')?.value || 0;
    this.invoiceForm.get('total')?.setValue(qty * price);
  }

  addToTable() {
    const formValue = this.invoiceForm.getRawValue();

    const newRow = {
      FRAN: '001',
      BRCH: '002',
      WHSE: '003',
      DOCDT: new Date().toISOString().split('T')[0],
      DOCTYPE: 'CREDIT',
      DOCNO: formValue.invoiceNo,
      DOCSRL: '01',

      MAKE: formValue.make,
      PART: formValue.product,
      QTY: formValue.quantity,
      PRICE: formValue.unitPrice,

      DISCOUNT: 0,
      VATVALUE: 0,
      DISCOUNTVALUE: 0,
      TOTALVALUE: formValue.quantity * formValue.unitPrice,

      CREATEDT: new Date().toISOString().split('T')[0],
      CREATEBY: 'ADMIN',
      CREATEREMARKS: 'Manual Entry',
      UPDATEDT: new Date().toISOString().split('T')[0],
      UPDATETM: new Date().toISOString(),
      UPDATEBY: 'ADMIN',
      UPDATEMARKS: 'Auto'
    };

    this.invoiceList.push(newRow);
    this.invoiceForm.reset();
  }

  onExcelUpload(event: any) {
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = (e: any) => {
      const binary = e.target.result;
      const wb = XLSX.read(binary, { type: 'binary' });
      const ws = wb.Sheets[wb.SheetNames[0]];

      const rawData = XLSX.utils.sheet_to_json(ws);
      console.log('RAW EXCEL:', rawData);

      const mappedRows = rawData.map((row: any) => ({
        FRAN: '001',
        BRCH: '002',
        WHSE: '003',

        DOCDT: new Date().toISOString().split('T')[0],
        DOCTYPE: 'CREDIT',
        DOCNO: row['Doc No'] || 'AUTO_CR_01',
        DOCSRL: '01',

        MAKE: row['Make'] || '',
        PART: row['Part'] || '',
        QTY: row['Quantity'] || 0,
        PRICE: row['Unit Price'] || 0,

        DISCOUNT: 0,
        VATVALUE: 0,
        DISCOUNTVALUE: 0,
        TOTALVALUE: row['Total'] || ((row['Quantity'] || 0) * (row['Unit Price'] || 0)),

        CREATEDT: new Date().toISOString().split('T')[0],
        CREATEBY: 'ADMIN',
        CREATEREMARKS: 'Excel Upload',

        UPDATEDT: new Date().toISOString().split('T')[0],
        UPDATETM: new Date().toISOString(),
        UPDATEBY: 'ADMIN',
        UPDATEMARKS: 'Auto Excel'
      }));

      console.log('Mapped Excel Data:', mappedRows);

      this.invoiceList.push(...mappedRows);
      this.invoiceList = [...this.invoiceList]; // refresh table
    };

    reader.readAsBinaryString(file);
  }

  submitInvoice() {

    if (this.invoiceList.length === 0) {
      alert('No invoice data to submit');
      return;
    }

    const payload = {
      saleinvoicerequest: this.invoiceList
    };

    console.log('Payload:', payload);

    this.apiService.saveSaleInvoice(payload).subscribe({
      next: (res) => {
        alert('Saved Successfully');
        this.invoiceList = [];
      },
      error: (err) => {
        console.error('API Error:', err);
        alert('Failed to save invoice. Check console.');
      }
    });
  }

  deleteInvoice(index: number) {
    this.invoiceList.splice(index, 1);
    this.invoiceList = [...this.invoiceList];
  }
}
