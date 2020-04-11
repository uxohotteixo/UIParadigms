import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-open',
  templateUrl: './open.component.html',
  styleUrls: ['./open.component.css']
})
export class OpenComponent implements OnInit {

  @Output() resultChange = new EventEmitter<string>();
  textInput = '';
  constructor(private service: AppService) { }

  ngOnInit(): void {
  }

  open(result) {
    return this.service.emitResult(this.resultChange, `open ${result}`, true);
  }
}
