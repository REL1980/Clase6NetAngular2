import { Component } from '@angular/core';
import { WeatherForecast, WeatherService } from '../services/weather.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent
{

  keyword:string = "";

  public forecasts: WeatherForecast[] = [];

  /**
   *
   * @param weatherService
   */
  constructor(private weatherService:WeatherService)
  {
    this.refresh();
  }

  // Método Refresh
  refresh()
  {
    this.weatherService.getWeather(this.keyword).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}


