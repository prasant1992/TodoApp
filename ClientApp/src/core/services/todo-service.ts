import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { ToDo } from './model/ToDo';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private http = inject(HttpClient);

  baseUrl = "http://localhost:5098";

  async getTodo(){
     try {
          return lastValueFrom(this.http.get<ToDo[]>(`${this.baseUrl}/ToDoItems/GetAll`))
        } catch (error) {
          console.log(error);
          throw error;
        }
  }

  async deleteTodo(id:number){
    try {
      return lastValueFrom(this.http.get<boolean>(`${this.baseUrl}/ToDoItems/Delete/${id}`))
    } catch (error) {
      throw error;
    }
  }

  create(item:ToDo){
    return this.http.post<ToDo>(`${this.baseUrl}/ToDoItems/Create`,item);
  }
  
}
