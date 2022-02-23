import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { GameComponent } from './game/game.component';
import { ShowGameComponent } from './game/show-game/show-game.component';
import { AddEditGameComponent } from './game/add-edit-game/add-edit-game.component';
import { GameApiService } from "./game-api.service";
import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
  declarations: [
    AppComponent,
    GameComponent,
    ShowGameComponent,
    AddEditGameComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule
  ],
  providers: [GameApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
