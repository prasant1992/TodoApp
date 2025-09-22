import { Routes } from '@angular/router';
import { App } from './app';
import { Create } from '../features/create/create';
import { Todolist } from '../features/todolist/todolist';

export const routes: Routes = [
    {path: '', component: Todolist},
    {path: 'create', component:Create},
    {path: '**', component:Todolist}
];
