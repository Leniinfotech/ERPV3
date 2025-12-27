import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ExpenseEntryComponent } from '../Expense-Entry/expense-entry.component';

describe('ExpenseEntry', () => {
  let component: ExpenseEntryComponent;
  let fixture: ComponentFixture<ExpenseEntryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExpenseEntryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExpenseEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
