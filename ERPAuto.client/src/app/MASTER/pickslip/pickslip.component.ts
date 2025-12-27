import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-pickslip',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './pickslip.html',
  styleUrls: ['./pickslip.css']
})
export class PickSlipComponent implements OnInit {

  pickSlips: any[] = [];
  newPickSlip: any = {
    fran: 'FR001',
    brch: 'BR001',
    whse: 'WH001'
  };

  readonly apiUrl = 'https://localhost:7261/api/PickSlips';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.loadPickSlips();
    this.getNextRefSrl();   // 🔥 Auto-load next serial number
  }

  // =======================================================
  // ✅ AUTO-INCREMENT REF SRL (Correct JSON key)
  // =======================================================
  getNextRefSrl(): void {
    const fran = this.newPickSlip.fran || 'FR001';

    this.http.get<any>(`${this.apiUrl}/NextRefSrl/${fran}`)
      .subscribe({
        next: (res) => {
          console.log("API Response = ", res);

          // 🔥 Correct key from your backend JSON:
          // {"fran":"FR001","nexT_REFSRL":1}
          this.newPickSlip.refsrl = res.nexT_REFSRL;

          console.log('🔢 Next RefSrl Loaded:', this.newPickSlip.refsrl);
        },
        error: (err) => {
          console.error('❌ Error loading RefSrl:', err);
          alert('Failed to load Ref Serial Number');
        }
      });
  }

  // =======================================================
  // ✅ FETCH ALL PICKSLIPS
  // =======================================================
  loadPickSlips(): void {
    this.http.get<any[]>(this.apiUrl).subscribe({
      next: (data) => {
        this.pickSlips = data || [];
        console.log('📦 PickSlips loaded:', this.pickSlips);
      },
      error: (err) => {
        console.error('❌ Error fetching PickSlips:', err);
        alert('Failed to fetch PickSlips.');
      }
    });
  }

  // =======================================================
  // ✅ SUBMIT NEW PICKSLIP
  // =======================================================
  onSubmit(): void {
    console.log('📝 Submitting PickSlip:', this.newPickSlip);

    this.newPickSlip.pickslipsrl = this.newPickSlip.pickslipsrl || 1;
    this.newPickSlip.pickslipstatus = this.newPickSlip.pickslipstatus || 'OPEN';

    this.newPickSlip.createdt = new Date().toISOString();
    this.newPickSlip.createtm = new Date().toISOString();
    this.newPickSlip.createby = 'ADMIN';

    this.http.post(this.apiUrl, this.newPickSlip).subscribe({
      next: (response) => {
        console.log('✅ PickSlip saved successfully:', response);
        alert('✅ PickSlip saved successfully!');

        // Reset with defaults
        this.newPickSlip = {
          fran: 'FR001',
          brch: 'BR001',
          whse: 'WH001'
        };

        // Load next Ref Srl again
        this.getNextRefSrl();
        this.loadPickSlips();
      },
      error: (error) => {
        console.error('❌ Error saving PickSlip:', error);
        alert('❌ Error saving PickSlip!');
      }
    });
  }
}
