import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import Swal from 'sweetalert2';
import * as XLSX from 'xlsx';

import { ApiService, Customer } from '../../services/api.service';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  // ================= DATA =================
  customers: Customer[] = [];
  filteredCustomers: Customer[] = [];
  paginatedCustomers: Customer[] = [];

  // ================= SEARCH =================
  searchFilters: any = {
    customerName: '',
    nameAr: '',
    phone: '',
    email: '',
    address: '',
    vatNo: ''
  };

  // ================= PAGINATION =================
  currentPage = 1;
  itemsPerPage = 5;
  totalPages = 1;
  totalItems = 0;

  // ================= MODAL =================
  showModal = false;
  isEditMode = false;
  customerForm: Customer = this.getEmptyCustomer();

  // ================= VALIDATION =================
  emailError = '';
  phoneError = '';

  // ================= LOADING =================
  isLoading = false;

  constructor(private apiService: ApiService) { }

  // ================= INIT =================
  ngOnInit(): void {
    this.loadCustomers();
  }

  // ================= LOAD =================
  loadCustomers(): void {
    this.isLoading = true;

    this.apiService.getAllCustomers().subscribe({
      next: (data) => {
        const customers = Array.isArray(data) ? data : [];
        this.customers = customers;
        this.filteredCustomers = customers;
        this.totalItems = customers.length;
        this.currentPage = 1;
        this.updatePagination();
        this.isLoading = false;
      },
      error: (err) => {
        this.isLoading = false;
        Swal.fire('Error', err.message || 'Failed to load customers', 'error');
      }
    });
  }

  // ================= SEARCH =================
  onColumnSearch(): void {
    this.filteredCustomers = this.customers.filter(c =>
      (!this.searchFilters.customerName || c.name?.toLowerCase().includes(this.searchFilters.customerName.toLowerCase())) &&
      (!this.searchFilters.nameAr || c.nameAr?.toLowerCase().includes(this.searchFilters.nameAr.toLowerCase())) &&
      (!this.searchFilters.phone || c.phone?.includes(this.searchFilters.phone)) &&
      (!this.searchFilters.email || c.email?.toLowerCase().includes(this.searchFilters.email.toLowerCase())) &&
      (!this.searchFilters.address || c.address?.toLowerCase().includes(this.searchFilters.address.toLowerCase())) &&
      (!this.searchFilters.vatNo || c.vatNo?.toLowerCase().includes(this.searchFilters.vatNo.toLowerCase()))
    );

    this.currentPage = 1;
    this.updatePagination();
  }

  clearAllFilters(): void {
    this.searchFilters = {
      customerName: '',
      nameAr: '',
      phone: '',
      email: '',
      address: '',
      vatNo: ''
    };
    this.onColumnSearch();
  }

  // ================= PAGINATION =================
  updatePagination(): void {
    this.totalItems = this.filteredCustomers.length;

    if (this.itemsPerPage === 0) {
      this.paginatedCustomers = this.filteredCustomers;
      this.totalPages = 1;
      return;
    }

    this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage) || 1;
    const start = (this.currentPage - 1) * this.itemsPerPage;
    const end = start + this.itemsPerPage;
    this.paginatedCustomers = this.filteredCustomers.slice(start, end);
  }

  changePage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.updatePagination();
    }
  }

  onItemsPerPageChange(): void {
    this.currentPage = 1;
    this.updatePagination();
  }

  getPageNumbers(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  // ================= MODAL =================
  openAddModal(): void {
    this.isEditMode = false;
    this.customerForm = this.getEmptyCustomer();
    this.emailError = '';
    this.phoneError = '';
    this.showModal = true;
  }

  openEditModal(customer: Customer): void {
    this.isEditMode = true;
    this.customerForm = { ...customer };
    this.showModal = true;
  }

  closeModal(): void {
    this.showModal = false;
    this.customerForm = this.getEmptyCustomer();
    this.isEditMode = false;
  }

  // ================= VALIDATION =================
  validateEmail(email: string): boolean {
    const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return regex.test(email);
  }

  validatePhone(phone: string): boolean {
    return /^[0-9]+$/.test(phone);
  }

  validateForm(): boolean {
    if (!this.customerForm.customerCode) {
      Swal.fire('Validation Error', 'Customer Code is required', 'warning');
      return false;
    }
    if (!this.customerForm.name) {
      Swal.fire('Validation Error', 'Customer Name is required', 'warning');
      return false;
    }
    if (!this.customerForm.nameAr) {
      Swal.fire('Validation Error', 'Arabic Name is required', 'warning');
      return false;
    }
    if (!this.validatePhone(this.customerForm.phone)) {
      Swal.fire('Validation Error', 'Phone must contain only numbers', 'warning');
      return false;
    }
    if (!this.validateEmail(this.customerForm.email)) {
      Swal.fire('Validation Error', 'Invalid Email Address', 'warning');
      return false;
    }
    if (!this.customerForm.address) {
      Swal.fire('Validation Error', 'Address is required', 'warning');
      return false;
    }
    if (!this.customerForm.vatNo) {
      Swal.fire('Validation Error', 'VAT No is required', 'warning');
      return false;
    }
    return true;
  }

  // ================= SAVE =================
  saveCustomer(): void {
    if (!this.validateForm()) return;

    if (this.isEditMode) {
      this.apiService.updateCustomer(this.customerForm.customerCode, this.customerForm).subscribe({
        next: () => {
          Swal.fire('Success', 'Customer updated successfully', 'success');
          this.closeModal();
          this.loadCustomers();
        },
        error: err => Swal.fire('Error', err.message, 'error')
      });
    } else {
      this.apiService.addCustomer(this.customerForm).subscribe({
        next: () => {
          Swal.fire('Success', 'Customer added successfully', 'success');
          this.closeModal();
          this.loadCustomers();
        },
        error: err => Swal.fire('Error', err.message, 'error')
      });
    }
  }

  // ================= DELETE =================
  deleteCustomer(customer: Customer): void {
    Swal.fire({
      title: 'Are you sure?',
      text: `Delete ${customer.name}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33'
    }).then(res => {
      if (res.isConfirmed) {
        this.apiService.deleteCustomer(customer.customerCode).subscribe({
          next: () => {
            Swal.fire('Deleted', 'Customer deleted successfully', 'success');
            this.loadCustomers();
          },
          error: err => Swal.fire('Error', err.message, 'error')
        });
      }
    });
  }

  // ================= EXPORT =================
  exportToExcel(): void {
    const data = this.filteredCustomers.map((c, i) => ({
      'S.No': i + 1,
      'Customer Code': c.customerCode,
      'Name': c.name,
      'Name(AR)': c.nameAr,
      'Phone': c.phone,
      'Email': c.email,
      'Address': c.address,
      'VAT No': c.vatNo
    }));

    const worksheet = XLSX.utils.json_to_sheet(data);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, 'Customers');

    XLSX.writeFile(
      workbook,
      `Customers_${new Date().toISOString().split('T')[0]}.xlsx`
    );
  }

  // ================= UTILS =================
  getEmptyCustomer(): Customer {
    return {
      customerCode: '',
      name: '',
      nameAr: '',
      phone: '',
      email: '',
      address: '',
      vatNo: ''
    };
  }

  Math = Math;
}
