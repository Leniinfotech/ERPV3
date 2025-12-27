import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import Swal from 'sweetalert2';
import { ApiService } from '../../services/api.service';

@Component({
  standalone: true,
  selector: 'app-account-receivable',
  imports: [CommonModule, FormsModule],
  templateUrl: './accountreceivable.component.html',
  styleUrls: ['./accountreceivable.component.css']
})
export class AccountReceivable implements OnInit {

  receivableList: any[] = [];
  filteredList: any[] = [];
  pagedList: any[] = [];

  searchCustomer = '';
  searchInvoice = '';
  searchStatus = '';
  searchInvDate = '';
  searchDueDate = '';
  currentPage = 1;
  pageSize = 10;
  totalPages = 0;
  totalPagesArray: number[] = [];

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.loadReceivables();
  }

  formatDate(dateStr: string): string {
    if (!dateStr) return '';
    if (/^\d{2}-\d{2}-\d{4}$/.test(dateStr)) return dateStr;

    const date = new Date(dateStr);
    if (isNaN(date.getTime())) return '';

    return `${String(date.getDate()).padStart(2, '0')}-${String(date.getMonth() + 1).padStart(2, '0')}-${date.getFullYear()}`;
  }

  loadReceivables() {
    const fran = 'A';

    this.api.getReceivables(fran).subscribe({
      next: (res: any) => {

        const data = Array.isArray(res) ? res : res.data;

        this.receivableList = data.map((x: any) => ({
          customer: x.customer,
          invoice: x.invoiceNo,
          invoiceDate: this.formatDate(x.invoiceDate),
          dueDate: this.formatDate(x.dueDate),
          totalAmount: x.totalValue,
          paidAmount: Number(x.paid) || 0,
          pendingAmount: Number(x.pending) || 0,
          status: (x.status || '').toUpperCase()
        }));

        this.filteredList = [...this.receivableList];
        this.setupPagination();
      },
      error: () =>
        Swal.fire('Error', 'Unable to load receivable records.', 'error')
    });
  }

  setupPagination() {
    this.totalPages = Math.max(1, Math.ceil(this.filteredList.length / this.pageSize));
    this.totalPagesArray = Array.from({ length: this.totalPages }, (_, i) => i + 1);
    this.changePage(1);
  }

  changePage(page: number) {
    this.currentPage = page;
    const start = (page - 1) * this.pageSize;
    this.pagedList = this.filteredList.slice(start, start + this.pageSize);
  }

  onSearch() {
    let filtered = [...this.receivableList];

    if (this.searchCustomer.trim()) {
      const s = this.searchCustomer.toLowerCase();
      filtered = filtered.filter(x => x.customer?.toLowerCase().includes(s));
    }

    if (this.searchInvoice.trim()) {
      const s = this.searchInvoice.toLowerCase();
      filtered = filtered.filter(x => x.invoice?.toLowerCase().includes(s));
    }

    if (this.searchStatus.trim()) {
      const s = this.searchStatus.toUpperCase();
      filtered = filtered.filter(x => x.status?.toUpperCase() === s);
    }

    if (this.searchInvDate.trim()) {
      const d = this.formatDate(this.searchInvDate);
      filtered = filtered.filter(x => x.invoiceDate === d);
    }

    if (this.searchDueDate.trim()) {
      const d = this.formatDate(this.searchDueDate);
      filtered = filtered.filter(x => x.dueDate === d);
    }

    this.filteredList = filtered;
    this.setupPagination();
  }

  openPayment(item: any) {
    if (item.status.toUpperCase() === 'PAID') {
      Swal.fire('Already Paid', 'This invoice is fully paid.', 'info');
      return;
    }

    sessionStorage.setItem('invoice', item.invoice);
    sessionStorage.setItem('bill', item.totalAmount);
    sessionStorage.setItem('pending', item.pendingAmount);
    sessionStorage.setItem('saleDate', item.invoiceDate);
    sessionStorage.setItem('customer', item.customer);

    // ✅ ADD THIS
    sessionStorage.setItem('paymentSource', 'RECEIVABLE');

    window.location.href = '/payment';
  }
}
