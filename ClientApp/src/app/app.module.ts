import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { VideoDialog } from './video-dialog/video.dialog';
import { HomeComponent } from './home/home.component';
import { LocflixService } from './services/locflix.service';
import { HttpClientModule } from '../../node_modules/@angular/common/http';
import { MatDialogModule } from '../../node_modules/@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    VideoDialog
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSidenavModule,
    MatToolbarModule,
    MatDialogModule
  ],
  providers: [LocflixService],
  bootstrap: [AppComponent],
  entryComponents:[
    VideoDialog
  ]
})
export class AppModule { }
