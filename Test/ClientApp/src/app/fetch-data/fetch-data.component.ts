import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public estoques: Estoques[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Estoques[]>(baseUrl + 'api/Estoques').subscribe(result => {
      this.estoques = result;
    }, error => console.error(error));
  }
}

interface Estoques {
  filial: string;
  descricao: number;
  quantidade: number;
}
