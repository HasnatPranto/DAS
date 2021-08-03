import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  docView = false;

  constructor() { }

  ngOnInit(): void {
  }

  toggleDocView(){
    this.docView = !this.docView;
  }
  isDocView(){
    return this.docView;
  }
}
