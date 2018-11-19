import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <mat-toolbar style="color:black;background:white;font-family:verdana;Border-Bottom:0.1px solid #BABABA">
  <span class="largeTitle">Blockchain Toollending Tool </span>
  <span style="flex: 1 1 auto"></span>
  <span style="padding: 0 14px;cursor:pointer" [routerLink]="[ 'user']"> User </span>
  <span style="padding: 0 14px;cursor:pointer" [routerLink]="[ 'tools']"> Tools </span>
  <span style="padding: 0 14px;cursor:pointer" [routerLink]="[ 'transaction']"> Transaction </span>
</mat-toolbar>
<div class="container" style="background:#F0F0F0">
  <router-outlet></router-outlet>
</div> 
      `,
  styles: []
})
export class AppComponent {
  title = 'app';
}
