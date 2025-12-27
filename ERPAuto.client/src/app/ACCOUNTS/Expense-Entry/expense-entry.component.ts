import { Component } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-Expense-Entry',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './expense-entry.component.html',
  styleUrls: ['./expense-entry.component.css'],
})
export class ExpenseEntryComponent {

  expenseDate!: string;

  constructor(private apiService: ApiService) {
    this.setTodayDate();
  }

  setTodayDate() {
    const today = new Date();
    this.expenseDate = today.toISOString().split('T')[0];
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      const expenseData = form.value;

      this.apiService.addExpenseEntry(expenseData).subscribe({
        next: (res: any) => {
          Swal.fire({
            icon: 'success',
            title: 'Success',
            text: 'Expense entry submitted successfully!',
          });

          form.resetForm({
            expenseDate: this.expenseDate
          });
        },
        error: (err: any) => {
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Failed to submit expense entry. Please try again.',
          });
        }
      });
    }
  }
}
