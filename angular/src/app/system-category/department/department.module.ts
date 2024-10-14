import { NgModule } from '@angular/core';

import { DepartmentRoutingModule } from './department-routing.module';
import { DepartmentComponent } from './components/department.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    declarations: [DepartmentComponent],
    imports: [SharedModule, DepartmentRoutingModule],
})
export class DepartmentModule {}
