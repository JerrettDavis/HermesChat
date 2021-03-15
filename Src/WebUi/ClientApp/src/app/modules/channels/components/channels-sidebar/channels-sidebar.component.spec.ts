import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChannelsSidebarComponent } from './channels-sidebar.component';

describe('ChannelsSidebarComponent', () => {
  let component: ChannelsSidebarComponent;
  let fixture: ComponentFixture<ChannelsSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChannelsSidebarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChannelsSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
