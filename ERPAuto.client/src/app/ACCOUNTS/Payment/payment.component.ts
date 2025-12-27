import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import Swal from 'sweetalert2';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
})
export class Payment implements OnInit {

  paymentMethod = '';
  cardNumber = '';
  remarks = '';
  saleDate: any = '';
  saleNo = '';
  billAmount = 0;
  paynowAmount = 0;
  receivableAmount = 0;

  paymentSource = '';
  billSummaryTitle = 'Receivables';
  constructor(private route: ActivatedRoute, private api: ApiService) { }

  ngOnInit(): void {
    this.saleNo = sessionStorage.getItem('invoice') || '';
    this.billAmount = Number(sessionStorage.getItem('bill')) || 0;
    this.receivableAmount = Number(sessionStorage.getItem('pending')) || 0;
    this.saleDate = sessionStorage.getItem('saleDate') || '';
    this.paynowAmount = 0;

    this.paymentSource = sessionStorage.getItem('paymentSource') || '';

    if (this.paymentSource === 'PAYABLE') {
      this.billSummaryTitle = 'Payables';
    } else {
      this.billSummaryTitle = 'Receivables';
    }

  }

  // Confirm Payment → Call only JOURNALENTRIES/Pay API
  confirmPayment() {

    if (!this.paynowAmount || this.paynowAmount <= 0) {
      Swal.fire({
        icon: 'warning',
        title: 'Warning',
        text: 'Please enter a valid Pay Now Amount!'
      });
      return;
    }

    if (!this.paymentMethod) {
      Swal.fire({
        icon: 'warning',
        title: 'Warning',
        text: 'Please select a Payment Method!'
      });
      return;
    }

    const body = {
      customer: sessionStorage.getItem('customer') || '',
      saleNo: this.saleNo,
      billAmount: Number(this.paynowAmount),
      paymentMethod: this.paymentMethod,
      cardNumber: this.cardNumber || '',
      remarks: this.remarks || ''
    };

    // CALL INSERT JOURNAL API
    this.api.addJournalEntry(body).subscribe({
      next: (res) => {

        Swal.fire({
          icon: 'success',
          title: 'Payment Successful',
          text: res?.message || 'Payment successfully recorded',
          confirmButtonText: 'OK'
        }).then(() => {

          const source = sessionStorage.getItem('paymentSource');

          // cleanup (optional but recommended)
          sessionStorage.removeItem('paymentSource');

          if (source === 'PAYABLE') {
            window.location.href = '/accountpayable';
          }
          else if (source === 'RECEIVABLE') {
            window.location.href = '/accountreceivable';
          }
          else {
            // fallback
            window.location.href = '/';
          }
        });
      },
      error: (err) => {
        console.error('Journal insert error:', err);
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: 'Payment failed!'
        });
      }
    });
  }
  printPage() {
    window.print();
  }
}
