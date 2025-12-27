import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickslipInquiry } from './pickslip-inquiry';

describe('PickslipInquiry', () => {
  let component: PickslipInquiry;
  let fixture: ComponentFixture<PickslipInquiry>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PickslipInquiry]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PickslipInquiry);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
