import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AccountReceivable } from '../AccountReceivable/accountreceivable.component';

describe('InvoiceAR', () => {
  let component: AccountReceivable;
  let fixture: ComponentFixture<AccountReceivable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccountReceivable]
    })
      .compileComponents();

    fixture = TestBed.createComponent(AccountReceivable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
