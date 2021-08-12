import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Photo } from '../models/photo/photo.model';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  private apiURL = environment.webApi + '/Photo';

  constructor(private http: HttpClient) { }

  create(model: FormData): Observable<Photo> {
    return this.http.post<Photo>(`${this.apiURL}`, model);
  }

  getByApplicationUserId():  Observable<Photo[]> {
    return this.http.get<Photo[]>(`${this.apiURL}`);
  }

  get(photoId: number): Observable<Photo> {
    return this.http.get<Photo>(`${this.apiURL}/${photoId}`);
  }

  delete(photoId: number):  Observable<number> {
    return this.http.delete<number>(`${this.apiURL}/${photoId}`);
  }


}
