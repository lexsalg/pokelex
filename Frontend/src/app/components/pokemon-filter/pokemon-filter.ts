import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { Pokemon } from 'src/app/models';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'pokemon-filter',
  templateUrl: './pokemon-filter.html',
  styleUrls: ['./pokemon-filter.scss']
})
export class PokemonFilter implements OnInit {

  f: FormGroup;

  @Output() formChange = new EventEmitter();

  obs: Subscription;

  constructor(private fb: FormBuilder, private api: ApiService) {

  }

  ngOnInit(): void {
    this.initForm();
    this.changeName();
  }

  ngOnDestroy(): void {
    this.obs.unsubscribe();
  }

  initForm() {
    this.f = this.fb.group({ nombre: '', tipo: '' });
  }

  changeName() {
    this.obs = this.f.get('nombre').valueChanges
      .pipe(debounceTime(500))
      .subscribe(value => this.formChange.emit(value));
  }
}
