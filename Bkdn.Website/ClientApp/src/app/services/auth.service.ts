import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Token} from '../models/auth/Token';
import {LoginForm} from '../models/auth/LoginForm';

const userToken = 'userToken';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<Token> {
    const loginForm = new LoginForm(username, password);
    return this.http.post<Token>('api/auth', loginForm);
  }

  isLoggedIn() {
    return !!localStorage.getItem(userToken);
  }

  setToken(token: string) {
    localStorage.setItem(userToken, token);
  }

  deleteToken() {
    localStorage.clear();
  }
}
