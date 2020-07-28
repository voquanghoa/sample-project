import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu-admin',
  templateUrl: './nav-menu-admin.component.html',
  styleUrls: ['./nav-menu-admin.component.css']
})
export class NavMenuAdminComponent implements OnInit {

  isExpanded = false;

  ngOnInit() {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

}
