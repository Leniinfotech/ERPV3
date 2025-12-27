import { Component,OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-chartofaccount',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './chart_of_account.component.html',
  styleUrl: './chart_of_account.component.css',
})
export class ChartOfAccountComponent {

  accountType: string = '';

  onSubmit() {
    console.log(this.accountType);
  }
}
