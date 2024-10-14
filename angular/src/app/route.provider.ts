import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
    { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
    return () => {
        routes.add([
            {
                path: '/',
                name: '::Menu:Home',
                iconClass: 'fas fa-home',
                order: 1,
                layout: eLayoutType.application,
            },
            {
                path: '/book-store',
                name: '::Menu:BookStore',
                iconClass: 'fas fa-book',
                order: 2,
                layout: eLayoutType.application,
                requiredPolicy: 'BookStore.Books || BookStore.Authors',
            },
            {
                path: '/books',
                name: '::Menu:Books',
                parentName: '::Menu:BookStore',
                layout: eLayoutType.application,
                requiredPolicy: 'BookStore.Books',
            },
            {
                path: '/authors',
                name: '::Menu:Authors',
                parentName: '::Menu:BookStore',
                layout: eLayoutType.application,
                requiredPolicy: 'BookStore.Authors',
            },
            {
                path: '/system-category',
                name: '::Menu:SystemCategory',
                iconClass: 'fas fa-list',
                order: 3,
                layout: eLayoutType.application,
            },
            {
                path: '/currencies',
                name: '::Menu:Currencies',
                parentName: '::Menu:SystemCategory',
                layout: eLayoutType.application,
            },
            {
                path: '/departments',
                name: '::Menu:Departments',
                parentName: '::Menu:SystemCategory',
                layout: eLayoutType.application,
            },
            ,
            {
                path: '/expense-codes',
                name: '::Menu:ExpenseCodes',
                parentName: '::Menu:SystemCategory',
                layout: eLayoutType.application,
            },
            ,
            {
                path: '/kind-of-fals',
                name: '::Menu:KindOfFals',
                parentName: '::Menu:SystemCategory',
                layout: eLayoutType.application,
            },
            ,
            {
                path: '/vats',
                name: '::Menu:VATs',
                parentName: '::Menu:SystemCategory',
                layout: eLayoutType.application,
            },
        ]);
    };
}
