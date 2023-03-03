import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-cdb-investiment',
  templateUrl: './cdb-investiment.component.html',
  styleUrls: ['./cdb-investiment.component.css']
})
export class CdbInvestimentComponent implements OnInit {
    amount: number;
    months: number;
    result: number;
    _baseurl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseurl = baseUrl;
    }
    
  ngOnInit() {
  }

    calcularInvestimento() {
        const url = '';
        const body = {
            amount: this.amount,
            months: this.months
        }

        this.http.post(this._baseurl + 'CDB/calcularInvestimento', body).subscribe(
            (response: any) => {
                this.result = response.result;
            },
            (error: any) => {
                console.error(error);
            }
        );
    }

}
