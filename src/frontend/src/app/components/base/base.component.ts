import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {AppService} from '../../app.service';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export class BaseComponent implements OnInit {

  @Input() method;
  @Input() inputRequired;
  @Input() labelName;
  @Input() btnMessage;
  @Input() placeHolderMessage;
  @Output() resultChange = new EventEmitter<string>();
  textInput = '';
  constructor(private service: AppService) { }

  ngOnInit(): void {
  }

  apply() {
    return this.resultChange.emit(this.textInput);
  }

}
