import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {AppService} from '../../app.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  @Output() resultChange = new EventEmitter<string>();

  constructor(public service: AppService) {
  }

  ngOnInit(): void {
  }

  create(result) {
    return this.service.emitResult(this.resultChange, `create ${result}`, false);
  }
}
