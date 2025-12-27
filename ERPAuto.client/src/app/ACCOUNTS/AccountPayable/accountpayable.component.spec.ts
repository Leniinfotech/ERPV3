import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AccountPayable } from './accountpayable.component';

describe('AccountPayable', () => {
  let component: AccountPayable;
  let fixture: ComponentFixture<AccountPayable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccountPayable]
    })
      .compileComponents();

    fixture = TestBed.createComponent(AccountPayable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
