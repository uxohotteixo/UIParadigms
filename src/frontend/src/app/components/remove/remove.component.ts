import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {AppService} from '../../app.service';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css']
})
export class RemoveComponent implements OnInit {

  @Output() resultChange = new EventEmitter<string>();
  constructor(private service: AppService) { }

  ngOnInit(): void {
  }

  remove(result) {
    return this.service.emitResult(this.resultChange, `remove ${result}`, false);
  }
}
