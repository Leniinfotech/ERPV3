import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import Swal from 'sweetalert2';
import { ApiService } from '../../services/api.service';

@Component({
  standalone: true,
  imports: [CommonModule, FormsModule],
  selector: 'app-part-master.component',
  templateUrl: './part-master.component.html',
  styleUrls: ['./part-master.component.css']
})
export class PartComponent implements OnInit {
  //Dropdown data arrays
  makeList: any[] = [];
  invClassList: any[] = [];
  categoryList: any[] = [];
  groupList: any[] = [];
  cooList: any[] = [];

  partData = {
    partCode: '',
    make: '',
    invClass: '',
    category: '',
    group: '',
    coo: '',
    description: ''
  };

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.loadMakeList();
    //this.loadAllDropdowns();
    this.loadCategoryList();
    this.loadCooList();
    this.loadInvClassList();
    this.loadGroupList();
  }

  // Load Make List
  loadMakeList() {
    this.api.getMakeList().subscribe({
      next: data => this.makeList = data,
      error: err => console.error('Error loading makes', err)
    });
  }

  //loadAllDropdowns() {
  //  this.http.get<any>('https://localhost:7261/api/PARAMs/LoadAll').subscribe({
  //    next: (data) => {
  //      this.categoryList = data.categories;
  //      this.cooList = data.coo;
  //      this.invClassList = data.inventoryClass;
  //      this.groupList = data.groups;
  //    },
  //    error: (err) => console.error('Error loading dropdowns', err)
  //  });
  //}

  // CATEGORY
  loadCategoryList() {
    this.api.getParams('A', 'PMCATEGORY').subscribe({
      next: (data) => this.categoryList = data,
      error: (err) => console.error('Error loading category', err)
    });
  }

  loadCooList() {
    this.api.getParams('A', 'PARTS_COO').subscribe({
      next: (data) => this.cooList = data,
      error: (err) => console.error('Error loading COO', err)
    });
  }

  loadInvClassList() {
    this.api.getParams('A', 'INVENTORY_CLASS').subscribe({
      next: (data) => this.invClassList = data,
      error: (err) => console.error('Error loading invclass', err)
    });
  }

  loadGroupList() {
    this.api.getParams('A', 'PARTS_GROUP').subscribe({
      next: (data) => this.groupList = data,
      error: (err) => console.error('Error loading group', err)
    });
  }

  // SAVE PART
  onSubmit() {
    const payload = {
      fran: 'A',
      make: this.partData.make,
      partCode: this.partData.partCode,
      description: this.partData.description,
      invClass: this.partData.invClass,
      category: this.partData.category,
      group: this.partData.group,
      coo: this.partData.coo
    };

    this.api.addPart(payload).subscribe({
      next: () => {
        Swal.fire({
          icon: 'success',
          title: 'Part Saved!',
          text: 'The part has been saved successfully.'
        });
        this.resetForm();
      },
      error: (err) => {
        Swal.fire({
          icon: 'error',
          title: 'Save Failed!',
          text: err?.error?.message || 'Unable to save part.'
        });
      }
    });
  }

  resetForm() {
    this.partData = {
      partCode: '',
      make: '',
      invClass: '',
      category: '',
      group: '',
      coo: '',
      description: ''
    };
  }
}
