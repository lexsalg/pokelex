import { Component } from '@angular/core';
import { BlockUi } from './components';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Frontend';

  blockTemplate: BlockUi;
}
