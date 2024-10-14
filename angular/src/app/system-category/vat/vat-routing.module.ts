import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VatComponent } from './components/vat.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: VatComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class VatRoutingModule {}
