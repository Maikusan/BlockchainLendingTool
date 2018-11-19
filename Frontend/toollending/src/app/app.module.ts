import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { UserComponentComponent } from './user-component/user-component.component';
import { ToolsComponentComponent } from './tools-component/tools-component.component';
import { UserComponent } from './user.component';
import { ToolsComponent } from './tools.component';
import { TransactionsComponent } from './transactions.component';
import { DashboardComponent } from './dashboard/dashboard.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponentComponent,
    ToolsComponentComponent,
    UserComponent,
    ToolsComponent,
    TransactionsComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
