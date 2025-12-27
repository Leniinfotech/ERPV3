import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import Swal from 'sweetalert2';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-inquiry',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './inquiry.component.html',
  styleUrls: ['./inquiry.component.css']
})
export class InquiryComponent implements OnInit {
  searchKey: string = '';
  partDescription: string = '';
  allParts: any[] = [];       
  inquiryList: any[] = [];    
  paginatedList: any[] = [];
  currentPage: number = 1;
  totalPages: number[] = [1];
  itemsPerPage: number = 5;
  constructor(private router: Router, private api: ApiService) { }

  ngOnInit(): void {
    this.loadPartData();
  }

  // Load all part data from backend (Service Call)
  loadPartData(): void {
    this.api.getAllParts().subscribe({
      next: (data) => {
        this.allParts = data.map(p => ({
          ...p,
          category: p.category,
          subsPart: p.subsPart,
          finalPart: p.finalPart
        }));
        this.inquiryList = [...this.allParts];
        this.setupPagination();
      },
      error: (err) => {
        console.error('Error loading parts:', err);
        Swal.fire({
          icon: 'error',
          title: 'Failed to Load Data',
          text: 'Could not retrieve parts list from backend.'
        });
      }
    });
  }

  // Setup pagination once data loads
  setupPagination(): void {
    const pageCount = Math.ceil(this.inquiryList.length / this.itemsPerPage);
    this.totalPages = Array.from({ length: pageCount }, (_, i) => i + 1);
    this.changePage(1);
  }

  // Change page
  changePage(page: number): void {
    if (page < 1 || page > this.totalPages.length) return;
    this.currentPage = page;
    const startIndex = (page - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.paginatedList = this.inquiryList.slice(startIndex, endIndex);
  }

  // Search parts
  onSearch(): void {
    const key = this.searchKey.trim().toLowerCase();
    const desc = this.partDescription.trim().toLowerCase();

    this.inquiryList = this.allParts.filter(
      x =>
        (!key || x.partCode?.toLowerCase().includes(key)) &&
        (!desc || x.description?.toLowerCase().includes(desc))
    );

    this.setupPagination();
  }

  goToPartPage(): void {
    this.router.navigate(['/part']);
  }

  // Optional: Edit/Delete handlers
  editPart(part: any): void {
    Swal.fire('Edit feature', `Edit Part: ${part.partCode}`, 'info');
  }

  deletePart(part: any): void {
    Swal.fire({
      title: `Delete Part ${part.partCode}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!'
    }).then(result => {
      if (result.isConfirmed) {
        // Call API delete if implemented
        Swal.fire('Deleted!', `Part ${part.partCode} deleted.`, 'success');
      }
    });
  }
}
