import { Component } from '@angular/core';

@Component({
  selector: 'app-block-temp',
  styles: [`
    :host {
      text-align: center;    
      
    }
    img{
        width:200px;
      }
      .msg{
        font-size: 25px;
        color: white;
      }
  `],
  template: `
    <div class="block-ui-template">
      <img src="assets/loading.gif"alt="">
      <div class="msg">{{message}}</div>
    </div>
  `
})
export class BlockUi {
  message: any = 'Cargando...';
}
