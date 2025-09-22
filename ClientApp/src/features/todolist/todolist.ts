import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { TodoService } from '../../core/services/todo-service';
import { ToDo } from '../../core/services/model/ToDo';

@Component({
  selector: 'app-todolist',
  imports: [],
  templateUrl: './todolist.html',
  styleUrl: './todolist.css'
})
export class Todolist implements OnInit {
  private http = inject(HttpClient);
  private todoService = inject(TodoService);
  protected isEmpty = signal(true);
  protected todos = signal<ToDo[]>([]);

  async ngOnInit() {
    this.todos.set(await this.todoService.getTodo());
   
    if(this.todos().length > 0){
      this.isEmpty.set(false);
    }
  }

  deleteToDo(id:number){
    console.log(id);
  }

}
