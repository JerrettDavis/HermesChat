import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServersSidebarComponent } from './servers-sidebar.component';

describe('ServersSidebarComponent', () => {
  let component: ServersSidebarComponent;
  let fixture: ComponentFixture<ServersSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServersSidebarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServersSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
