import { Component, OnInit, Inject, NgModule} from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { NgxMaskModule} from 'ngx-mask'

@Component({
  selector: 'app-cdb-investiment',
  templateUrl: './cdb-investiment.component.html',
    styleUrls: ['./cdb-investiment.component.css'],
  //  imports: [NgxMaskDiretive],
})
//    export const options: Partial<null | IConfig> | (() => Partial<IConfig>) = null;
//    @NgModule({
//        declarations: [],
//        imports: [NgxMaskModule.forRoot(options),]
//})

export class CdbInvestimentComponent implements OnInit {
    amount: number;
    months: number;
    result: string;
    _baseurl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseurl = baseUrl;
    }
    
  ngOnInit() {
  }

    calcularInvestimento() {
        const url = '';
        const investimentCDBModel = {
            amount: this.amount,
            months: this.months
        }


        this.http.post(this._baseurl + 'CDB/calcularInvestimento', investimentCDBModel).subscribe(
            (response: any) => {
               var resposta = response;
                this.result = resposta.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
            },
            (error: any) => {
                console.error(error);
            }
        );

    }

}
