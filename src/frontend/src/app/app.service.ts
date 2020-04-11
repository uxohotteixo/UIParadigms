import {EventEmitter, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Subscribable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  private url = 'https://localhost:5001/commands/';

  constructor(private http: HttpClient) {
  }

  private get(params) {
    const methodName = <string> params.split(' ')[0];
    return this.http.get(this.url + `${methodName}?parameters=` + params);
  }

  private post(params) {
    const methodName = params.split(' ')[0];
    return this.http.post(this.url + methodName, {
      parameters: params
    });
  }

  public emitResult(emitter: EventEmitter<string>, params: string, isGet: boolean) {
    return isGet ? this.subs(this.get(params), emitter) : this.subs(this.post(params), emitter);
  }

  private subs(subs$: Subscribable<any>, emitter: EventEmitter<string>) {
    return subs$.subscribe(resp => {
      return emitter.emit(resp as any);
    }, resp => {
      return emitter.emit((resp as any).error.text);
    });
  }
}
