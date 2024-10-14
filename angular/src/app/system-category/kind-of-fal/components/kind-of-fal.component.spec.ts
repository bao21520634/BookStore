import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KindOfFalComponent } from './kind-of-fal.component';

describe('KindOfFalComponent', () => {
  let component: KindOfFalComponent;
  let fixture: ComponentFixture<KindOfFalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [KindOfFalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KindOfFalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
