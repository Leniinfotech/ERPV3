import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WorkmasterComponent } from './workmaster.component';

describe('WorkshopmasterComponent', () => {
  let component: WorkmasterComponent;
  let fixture: ComponentFixture<WorkmasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WorkmasterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WorkmasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
