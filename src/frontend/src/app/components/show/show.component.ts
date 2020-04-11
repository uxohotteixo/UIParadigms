import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {AppService} from '../../app.service';


@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  @Output() resultChange = new EventEmitter<string>();
  textInput = '';
  checkBoxInput = false;
  constructor(private service: AppService) {
  }

  ngOnInit(): void {
  }

  public show() {
    return this.service.emitResult(this.resultChange, `show ${this.textInput} ${this.checkBoxInput ? '-r' : ''}`, true);
  }

}
