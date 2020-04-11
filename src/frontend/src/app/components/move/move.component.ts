import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {AppService} from '../../app.service';

@Component({
  selector: 'app-move',
  templateUrl: './move.component.html',
  styleUrls: ['./move.component.css']
})
export class MoveComponent implements OnInit {

  @Output() resultChange = new EventEmitter<string>();
  constructor(private service: AppService) { }

  ngOnInit(): void {
  }

  move(result) {
    return this.service.emitResult(this.resultChange, `move ${result}`, false);
  }

}
