import { Routes } from '@angular/router';
import { FranComponent } from './MASTER/Fran/fran.component';
import { PartComponent } from './MASTER/part-master.component/part-master.component';
import { MasterComponent } from './MASTER/Master_Page/master.component';
import { InquiryComponent } from './MASTER/Inquiry/inquiry.component';
import { AccountReceivable } from './ACCOUNTS/AccountReceivable/accountreceivable.component';
import { AccountPayable } from './ACCOUNTS/AccountPayable/accountpayable.component';
//import { InvoiceAP } from './ACCOUNTS/Invoice-AP/invoice-ap.component';
//import { InvoiceAR } from './ACCOUNTS/Invoice-AR/invoice-ar.component';
import { Payment } from './ACCOUNTS/Payment/payment.component';
import { PickSlipComponent } from './MASTER/pickslip/pickslip.component';
import { PickslipInquiryComponent } from './MASTER/pickslip-inquiry/pickslip-inquiry';
import { ExpenseEntryComponent } from './ACCOUNTS/Expense-Entry/expense-entry.component';
import { ExpenseComponent } from './MASTER/Expense/expense.component';
import { SaleInvoiceComponent } from './SALES/Saleinvoice/sale-invoice.component';
import { WorkshopComponent } from './MASTER/Workshop/workshop.component';
import { CustomerComponent } from './MASTER/Customer/customer.component';
import { WorkmasterComponent } from './MASTER/Work-Master/workmaster.component';
import { ChartOfAccountComponent } from './ACCOUNTS/Chart_of_Account/chart_of_account.component';

export const routes: Routes = [
  {
    path: '', component: MasterComponent,
    children: [
      { path: 'fran', component: FranComponent },
      { path: 'part', component: PartComponent },
      { path: 'inquiry', component: InquiryComponent },
      { path: 'accountreceivable', component: AccountReceivable },
      { path: 'accountpayable', component: AccountPayable },
      //{ path: 'invoiceap', component: InvoiceAP },
      //{ path: 'invoicear', component: InvoiceAR },
      { path: 'payment', component: Payment },
      { path: 'pickslip-entry', component: PickSlipComponent },
      { path: 'pickslip-inquiry', component: PickslipInquiryComponent },
      { path: 'expense-entry', component: ExpenseEntryComponent },
      { path: 'expense', component: ExpenseComponent },
      { path: 'saleinvoice', component: SaleInvoiceComponent },
      { path: 'workshop', component: WorkshopComponent },
      { path: 'customer', component: CustomerComponent },
      { path: 'workmaster', component: WorkmasterComponent },
      { path: 'chartofaccount', component: ChartOfAccountComponent },
      
    ]
  }
];
