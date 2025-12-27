import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ChartOfAccountComponent } from './chart_of_account.component';

describe('ChartofAccountComponent', () => {
  let component: ChartOfAccountComponent;
  let fixture: ComponentFixture<ChartOfAccountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChartOfAccountComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChartOfAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
