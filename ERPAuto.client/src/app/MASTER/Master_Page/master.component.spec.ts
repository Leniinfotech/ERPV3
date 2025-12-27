import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MasterComponent } from '../Master_Page/master.component';

describe('Master', () => {
  let component: MasterComponent;
  let fixture: ComponentFixture<MasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MasterComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(MasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
