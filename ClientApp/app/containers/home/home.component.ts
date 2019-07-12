import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

    public urls = ['https://bento.cdn.pbs.org/hostedbento-prod/filer_public/Big%20Pacific/Photos/BigPacific_Promo_Thumb.jpg',
        'https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/17426200_1492058050807140_3398486175165708355_n.jpg?_nc_cat=103&_nc_oc=AQk6jKFAY_zvn3atmu1r76V6PqU5rbmDzlpnshaenKi1v-UTDVp2HNsio3MVNqO2ELo&_nc_ht=scontent-ams4-1.xx&oh=493600d8555022bfa704d9c56e2fcec2&oe=5DA76FA9']
    // Use "constructor"s only for dependency injection
    constructor(public translate: TranslateService, private http: HttpClient) {
    }

  // Here you want to handle anything with @Input()'s @Output()'s
  // Data retrieval / etc - this is when the Component is "ready" and wired up
  ngOnInit() {}

  public setLanguage(lang) {
    this.translate.use(lang);
  }
}
