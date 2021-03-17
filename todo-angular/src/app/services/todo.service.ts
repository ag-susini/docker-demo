import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class TodoService {
	url = 'http://localhost:5000/api/v1';
	constructor(private http: HttpClient) {}

	postToDo(toDoRequest: any) {
		return this.http.post<any>(`${this.url}/ToDo`, toDoRequest);
	}
	getToDos(): Observable<any[]> {
		return this.http.get<any[]>(`${this.url}/ToDo`);
	}
}
