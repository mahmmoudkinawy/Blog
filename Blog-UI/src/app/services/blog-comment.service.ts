import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BlogCommentCreate } from '../models/blog-comment/blog-comment-create.model';
import { BlogComment } from '../models/blog-comment/blog-comment.model';

@Injectable({
  providedIn: 'root'
})
export class BlogCommentService {

  private apiURL = environment.webApi + '/BlogComment';

  constructor(private http: HttpClient) { }

  create(model: BlogCommentCreate): Observable<BlogComment> {
    return this.http.post<BlogComment>(`${this.apiURL}`, model);
  }

  delete(blogCommentId: number): Observable<number> {
    return this.http.delete<number>(`${this.apiURL}/${blogCommentId}`);
  }

  getAll(blogId: number) : Observable<BlogComment[]> {
    return this.http.get<BlogComment[]>(`${this.apiURL}/${blogId}`);
  }



}
