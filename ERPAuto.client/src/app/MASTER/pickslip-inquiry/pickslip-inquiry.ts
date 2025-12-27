import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PickSlipInquiryService } from '../pickslip-inquiry/pickslip-inquiry.service';
import { DatePipe } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pickslip-inquiry',
  templateUrl: './pickslip-inquiry.html',
  styleUrls: ['./pickslip-inquiry.css'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    DatePipe
  ]
})
export class PickslipInquiryComponent implements OnInit {

  filterForm!: FormGroup;
  items: any[] = [];
  total: number = 0;
  page: number = 1;
  pageSize: number = 20;

  loading = false;

  // VIEW MODAL
  showViewModal = false;
  selectedItem: any = null;

  // EDIT MODAL
  showEditModal = false;
  editItem: any = {};

  constructor(
    private fb: FormBuilder,
    private service: PickSlipInquiryService,
    private router: Router     // ✅ Router added
  ) { }

  ngOnInit(): void {
    this.filterForm = this.fb.group({
      type: [''],
      number: [''],
      date: [''],
      search: ['']
    });

    this.loadData();
  }

  //---------------------------------------
  // + BUTTON → GO TO ENTRY PAGE
  //---------------------------------------
  goToEntry() {
    this.router.navigate(['/pickslip-entry']);
  }

  //---------------------------------------
  // LOAD DATA
  //---------------------------------------
  loadData() {
    this.loading = true;

    const filters = {
      ...this.filterForm.value,
      page: this.page,
      pageSize: this.pageSize
    };

    this.service.getInquiry(filters).subscribe({
      next: (res: any) => {
        this.items = res.items;
        this.total = res.total;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  //---------------------------------------
  // SEARCH
  //---------------------------------------
  onSearch() {
    this.page = 1;
    this.loadData();
  }

  //---------------------------------------
  // PAGINATION
  //---------------------------------------
  nextPage() {
    if (this.page * this.pageSize < this.total) {
      this.page++;
      this.loadData();
    }
  }

  prevPage() {
    if (this.page > 1) {
      this.page--;
      this.loadData();
    }
  }

  //---------------------------------------
  // VIEW MODAL
  //---------------------------------------
  onView(item: any) {
    this.selectedItem = item;
    this.showViewModal = true;
  }

  closeModal() {
    this.showViewModal = false;
  }

  //---------------------------------------
  // EDIT MODAL
  //---------------------------------------
  onEdit(item: any) {
    this.editItem = { ...item };

    // Fix date formatting for input type="date"
    if (this.editItem.pickslipdate) {
      this.editItem.pickslipdate = this.formatDate(this.editItem.pickslipdate);
    }

    this.showEditModal = true;
  }

  // Convert date → yyyy-MM-dd
  formatDate(dateString: string): string {
    const d = new Date(dateString);
    return d.toISOString().split('T')[0];
  }

  //---------------------------------------
  // SAVE EDIT
  //---------------------------------------
  saveEdit() {
    this.service.update(this.editItem).subscribe({
      next: () => {
        alert("Updated successfully!");
        this.showEditModal = false;
        this.loadData();
      },
      error: (err: any) => console.error(err)
    });
  }

  closeEditModal() {
    this.showEditModal = false;
  }
}
