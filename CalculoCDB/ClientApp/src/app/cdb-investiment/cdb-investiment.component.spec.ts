import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CdbInvestimentComponent } from './cdb-investiment.component';

describe('CdbInvestimentComponent', () => {
  let component: CdbInvestimentComponent;
  let fixture: ComponentFixture<CdbInvestimentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CdbInvestimentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CdbInvestimentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
