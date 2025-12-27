import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PickSlipComponent } from './pickslip.component';
import { PickSlipService } from './pickslip.service';

describe('PickSlipComponent', () => {
  let component: PickSlipComponent;
  let service: PickSlipService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PickSlipService]
    });

    service = TestBed.inject(PickSlipService);
    component = new PickSlipComponent(service);
  });

  it('should create PickSlip component', () => {
    expect(component).toBeTruthy();
  });

  it('should load PickSlips on init', () => {
    spyOn(service, 'getAll').and.callThrough();
    component.ngOnInit();
    expect(service.getAll).toHaveBeenCalled();
  });
});
