import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-expense',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './expense.component.html',
  styleUrls: ['./expense.component.css']
})
export class ExpenseComponent implements OnInit {

  searchKey: string = '';
  expenseType: string = '';
  Description: string = '';
  expenseList: any[] = [];
  filteredList: any[] = [];
  paginatedList: any[] = [];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  totalPages: number[] = [];

  constructor(
    private apiService: ApiService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadExpenses();
  }

  // ---------- LOAD EXPENSE LIST ----------
  loadExpenses(): void {
    this.apiService.getAllExpenses().subscribe({
      next: (res: any[]) => {
        this.expenseList = res || [];
        this.filteredList = [...this.expenseList];
        this.setupPagination();
      },
      error: (err) => {
        console.error('Error loading expenses', err);
      }
    });
  }

  // ---------- SEARCH ----------
  onSearch(): void {
    this.filteredList = this.expenseList.filter(expense =>
      (!this.searchKey ||
        expense.expenseId?.toString().toLowerCase().includes(this.searchKey.toLowerCase())) &&

      (!this.expenseType ||
        expense.expenseType?.toLowerCase().includes(this.expenseType.toLowerCase())) &&

      (!this.Description ||
        expense.description?.toLowerCase().includes(this.Description.toLowerCase()))
    );

    this.currentPage = 1;
    this.setupPagination();
  }

  // ---------- PAGINATION ----------
  setupPagination(): void {
    const totalItems = this.filteredList.length;
    const pageCount = Math.ceil(totalItems / this.itemsPerPage);

    this.totalPages = Array.from({ length: pageCount }, (_, i) => i + 1);
    this.updatePaginatedList();
  }

  updatePaginatedList(): void {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.paginatedList = this.filteredList.slice(startIndex, endIndex);
  }

  changePage(page: number): void {
    if (page < 1 || page > this.totalPages.length) {
      return;
    }
    this.currentPage = page;
    this.updatePaginatedList();
  }

  // ---------- NAVIGATION ----------
  goToExpensePage(): void {
    this.router.navigate(['/expense-entry']);
  }
}
