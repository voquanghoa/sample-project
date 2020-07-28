import {Component, OnInit} from '@angular/core';
import {AuthService} from '../services/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username = '';
  password = '';

  constructor(private authService: AuthService,
              private router: Router) {
  }

  ngOnInit(): void {
    if (this.authService.isLoggedIn()) {
      this.navigateToAdmin();
    }
  }

  navigateToAdmin() {
    this.router.navigateByUrl('/admin');
  }

  login() {
    this.authService.login(this.username, this.password)
      .subscribe(
        response => {
          this.authService.setToken(response.token);
          this.navigateToAdmin();
        },
        error => console.error('Error: ' + error),
      );
  }
}
