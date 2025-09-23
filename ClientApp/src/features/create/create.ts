import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { TodoService } from '../../core/services/todo-service';
import { ToDo } from '../../core/services/model/ToDo';
import { ToastService } from '../../core/services/toast-service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-create',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './create.html',
  styleUrl: './create.css'
})
export class Create implements OnInit {
  protected todoform:FormGroup = new FormGroup({});
  protected todoService = inject(TodoService);
  protected toastService = inject(ToastService);
  protected router = inject(Router);

  ngOnInit(): void {
    this.initialiseForm();
  }
  

initialiseForm(){
  this.todoform = new FormGroup({
    title: new FormControl("",Validators.required),
    description: new FormControl("",Validators.required)
  })
}

  onSubmit() {
    console.warn(this.todoform.value);
    let item:ToDo = {
      title:this.todoform.value.title,
      description: this.todoform.value.description,
      id:0
    };

    this.todoService.create(item).subscribe({
      next: response => {
        this.toastService.info("Item saved successfully")
        this.router.navigateByUrl("/");
      },
      error:error => this.toastService.error("Unable to save entry")
    });
  }
}
