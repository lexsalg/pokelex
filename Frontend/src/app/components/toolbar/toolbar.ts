import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'toolbar',
  templateUrl: './toolbar.html',
  styleUrls: ['./toolbar.scss']
})
export class ToolBar implements OnInit {

  date = new Date();

  constructor() { }

  ngOnInit(): void { }

}
