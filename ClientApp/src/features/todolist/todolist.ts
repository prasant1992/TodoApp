import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, inject, OnInit, signal } from '@angular/core';
import { TodoService } from '../../core/services/todo-service';
import { ToDo } from '../../core/services/model/ToDo';
import { Router, RouterLink } from '@angular/router';
import { ToastService } from '../../core/services/toast-service';


@Component({
  selector: 'app-todolist',
  imports: [RouterLink],
  templateUrl: './todolist.html',
  styleUrl: './todolist.css'
})
export class Todolist implements OnInit {
  private http = inject(HttpClient);
  private todoService = inject(TodoService);
  private toastService = inject(ToastService);
  private changeDetection = inject(ChangeDetectorRef)

  protected isEmpty = signal(true);
  protected todos = signal<ToDo[]>([]);

  async ngOnInit() {
    try {
      this.todos.set(await this.todoService.getTodo());
   
      if(this.todos().length > 0){
        this.isEmpty.set(false);
        this.toastService.info("Successfully retrieved list of todo's");
      }
    } catch (error) {
      console.log(error);
      this.toastService.error("An internal error has occurred");
    }
    
  }

  async deleteToDo(id:number){
    try {
      var isDeleted = (await this.todoService.deleteTodo(id));
      if(isDeleted){
        this.toastService.info("Successfully deleted item from list");
        this.todos.set(await this.todoService.getTodo());
      }
    } catch (error) {
      console.log(error);
      this.toastService.error("An internal error has occurred");
    }
  }

}
