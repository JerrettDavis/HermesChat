import {Component, NgModule} from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}

@NgModule({
  declarations: [CounterComponent]
})
export class CounterPageModule {}
