import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExpenseCodeComponent } from './components/expense-code.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: ExpenseCodeComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ExpenseCodeRoutingModule {}
