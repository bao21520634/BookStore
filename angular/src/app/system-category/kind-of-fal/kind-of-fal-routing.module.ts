import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KindOfFalComponent } from './components/kind-of-fal.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: KindOfFalComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class KindOfFalRoutingModule {}
