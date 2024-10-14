import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from './book/components/book.component';

const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
    },
    {
        path: 'account',
        loadChildren: () => import('@abp/ng.account').then((m) => m.AccountModule.forLazy()),
    },
    {
        path: 'identity',
        loadChildren: () => import('@abp/ng.identity').then((m) => m.IdentityModule.forLazy()),
    },
    {
        path: 'tenant-management',
        loadChildren: () => import('@abp/ng.tenant-management').then((m) => m.TenantManagementModule.forLazy()),
    },
    {
        path: 'setting-management',
        loadChildren: () => import('@abp/ng.setting-management').then((m) => m.SettingManagementModule.forLazy()),
    },
    {
        path: 'books',
        loadChildren: () => import('./book/book.module').then((m) => m.BookModule),
    },
    { path: 'authors', loadChildren: () => import('./author/author.module').then((m) => m.AuthorModule) },
    {
        path: 'vats',
        loadChildren: () => import('./system-category/vat/vat.module').then((m) => m.VatModule),
    },
    {
        path: 'currencies',
        loadChildren: () => import('./system-category/currency/currency.module').then((m) => m.CurrencyModule),
    },
    {
        path: 'departments',
        loadChildren: () => import('./system-category/department/department.module').then((m) => m.DepartmentModule),
    },
    {
        path: 'expense-codes',
        loadChildren: () =>
            import('./system-category/expense-code/expense-code.module').then((m) => m.ExpenseCodeModule),
    },
    {
        path: 'kind-of-fals',
        loadChildren: () => import('./system-category/kind-of-fal/kind-of-fal.module').then((m) => m.KindOfFalModule),
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes, {})],
    exports: [RouterModule],
})
export class AppRoutingModule {}
