import {Component, Inject, NgModule} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [FetchDataComponent]
})
export class FetchDataPageModule {}
