import { NgModule } from '@angular/core';

import { ExpenseCodeRoutingModule } from './expense-code-routing.module';
import { ExpenseCodeComponent } from './components/expense-code.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    declarations: [ExpenseCodeComponent],
    imports: [SharedModule, ExpenseCodeRoutingModule],
})
export class ExpenseCodeModule {}
