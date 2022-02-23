import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameApiService {

  readonly gameAPIUrl = "https://localhost:7051/api";

  constructor(private http:HttpClient) { }

  getGamesList():Observable<any[]> {
    return this.http.get<any>(this.gameAPIUrl + '/games');
  }

  addGames(data:any) {
    return this.http.post(this.gameAPIUrl + '/games', data);
  }

  updateGames(id:number|string, data:any) {
    return this.http.put(this.gameAPIUrl + `/games/${id}`, data);
  }

  deleteGames(id:number|string) {
    return this.http.delete(this.gameAPIUrl + `/games/${id}`);
  }

  // Category
  getCategoryList():Observable<any[]> {
    return this.http.get<any>(this.gameAPIUrl + '/GameСategory');
  }

  addCategory(data:any) {
    return this.http.post(this.gameAPIUrl + '/categGameСategoryory', data);
  }

  updateCategory(id:number|string, data:any) {
    return this.http.put(this.gameAPIUrl + `/GameСategory/${id}`, data);
  }

  deleteCategory(id:number|string) {
    return this.http.delete(this.gameAPIUrl + `/GameСategory/${id}`);
  }

  // Studio
  getStudioList():Observable<any[]> {
    return this.http.get<any>(this.gameAPIUrl + '/GameStudios');
  }

  addStudio(data:any) {
    return this.http.post(this.gameAPIUrl + '/GameStudios', data);
  }

  updateStudio(id:number|string, data:any) {
    return this.http.put(this.gameAPIUrl + `/GameStudios/${id}`, data);
  }

  deleteStudio(id:number|string) {
    return this.http.delete(this.gameAPIUrl + `/GameStudios/${id}`);
  }
}