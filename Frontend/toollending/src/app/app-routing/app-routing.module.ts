import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from '../components/user.component';
import { TransactionsComponent } from '../components/transactions.component';
import { ToolsComponent } from '../components/tools.component';

const routes: Routes = [
  { path: 'user', component: UserComponent },
  { path: 'tools',        component: ToolsComponent },
  { path: 'transaction',        component: TransactionsComponent },
  { path: '',   redirectTo: '/user', pathMatch: 'full' },
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ],
    declarations: []
})
export class AppRoutingModule { }