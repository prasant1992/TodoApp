import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { Nav } from "../layout/nav/nav";
import { Todolist } from "../features/todolist/todolist";


@Component({
  selector: 'app-root',
  imports: [Nav, Todolist],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  
  protected readonly title = "ToDo App";

  
}
