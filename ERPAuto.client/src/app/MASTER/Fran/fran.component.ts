import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FranService, Fran } from './fran.service';

@Component({
  selector: 'app-fran',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './fran.component.html',
  styleUrls: ['./fran.component.css'],
})
export class FranComponent implements OnInit {
  // 🔹 List of all FRAN records
  franList: Fran[] = [];

  // 🔹 Form object (matches backend model fields)
  franObj: Fran = {
    franCode: '',
    name: '',
    nameAr: ''
  };

  // 🔹 Edit mode flag
  isEditMode = false;

  constructor(private franService: FranService) { }

  ngOnInit(): void {
    this.loadFran();
  }

  // 🔹 Load all FRAN data from API
  loadFran() {
    this.franService.getAll().subscribe({
      next: (res) => (this.franList = res),
      error: (err) => console.error('Error loading FRAN data:', err)
    });
  }

  // 🔹 Handle form submit (create or update)
  onSubmit() {
    if (!this.franObj.franCode || !this.franObj.name || !this.franObj.nameAr) {
      alert('Please fill all required fields.');
      return;
    }

    if (this.isEditMode) {
      // ✅ Use franCode (string key), not id
      this.franService.update(this.franObj.franCode, this.franObj).subscribe({
        next: () => {
          alert('FRAN record updated successfully.');
          this.loadFran();
          this.resetForm();
        },
        error: (err) => console.error('Error updating FRAN:', err)
      });
    } else {
      this.franService.create(this.franObj).subscribe({
        next: () => {
          alert('FRAN record added successfully.');
          this.loadFran();
          this.resetForm();
        },
        error: (err) => console.error('Error creating FRAN:', err)
      });
    }
  }

  // 🔹 Edit a record
  editFran(fran: Fran) {
    this.franObj = { ...fran };
    this.isEditMode = true;
  }

  // 🔹 Delete a record (by franCode)
  deleteFran(franCode: string) {
    if (confirm('Are you sure you want to delete this record?')) {
      this.franService.delete(franCode).subscribe({
        next: () => {
          alert('FRAN deleted successfully.');
          this.loadFran();
        },
        error: (err) => console.error('Error deleting FRAN:', err)
      });
    }
  }

  // 🔹 Reset form
  resetForm() {
    this.franObj = {
      franCode: '',
      name: '',
      nameAr: ''
    };
    this.isEditMode = false;
  }
}
