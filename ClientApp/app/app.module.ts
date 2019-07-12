import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  BrowserModule,
  BrowserTransferStateModule
} from '@angular/platform-browser';
import { PreloadAllModules, RouterModule } from '@angular/router';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';
import { TransferHttpCacheModule } from '@nguniversal/common';
// i18n support
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { AccordionModule } from 'ngx-bootstrap';
import { AppComponent } from './app.component';
import { HomeComponent } from './containers/home/home.component';
import { NotFoundComponent } from './containers/not-found/not-found.component';
import { LinkService } from './shared/link.service';
import {SlideshowModule} from 'ng-simple-slideshow'

export function createTranslateLoader(http: HttpClient, baseHref) {
  // Temporary Azure hack
  if (baseHref === null && typeof window !== 'undefined') {
    baseHref = window.location.origin;
  }
  // i18n files are in `wwwroot/assets/`
  return new TranslateHttpLoader(http, `${baseHref}/assets/i18n/`, '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundComponent,
  ],
  imports: [
    SlideshowModule,
    CommonModule,
    BrowserModule.withServerTransition({
      appId: 'my-app-id' // make sure this matches with your Server NgModule
    }),
    HttpClientModule,
    TransferHttpCacheModule,
    BrowserTransferStateModule,
    FormsModule,
    ReactiveFormsModule,
    AccordionModule.forRoot(), // You could also split this up if you don't want the Entire Module imported

    // i18n support
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient, [ORIGIN_URL]]
      }
    }),

    // App Routing
    RouterModule.forRoot(
      [
        {
          path: '',
          redirectTo: 'home',
          pathMatch: 'full'
        },
        {
          path: 'home',
          component: HomeComponent,

          // *** SEO Magic ***
          // We're using "data" in our Routes to pass in our <title> <meta> <link> tag information
            // Note: This is only happening for ROOT level Routes, you'd have to add some 
            // additional logic if you wanted this for Child level routing
          // When you change Routes it will automatically append these to your document for you on the Server-side
          //  - check out app.component.ts to see how it's doing this
          data: {
            title: 'Homepage',
            meta: [
              {
                name: 'description',
                content: 'This is an example Description Meta tag!'
              }
            ],
            links: [
              { rel: 'canonical', href: 'http://blogs.example.com/blah/nice' },
              {
                rel: 'alternate',
                hreflang: 'es',
                href: 'http://es.example.com/'
              }
            ]
          }
        }],
      {
        // Router options
        useHash: false,
        preloadingStrategy: PreloadAllModules,
        initialNavigation: 'enabled'
      }
    )
  ],
  providers: [LinkService, TranslateModule],
  bootstrap: [AppComponent]
})
export class AppModuleShared {}
