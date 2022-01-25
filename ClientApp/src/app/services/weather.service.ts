import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService
{
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string)
  {

  }

  getWeather(keyword:string): Observable<WeatherForecast[]>
  {
    return this.http.get<WeatherForecast[]>(this.baseUrl + 'weatherforecast?keyword=' + keyword);
  }

}

export interface WeatherForecast
{
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
