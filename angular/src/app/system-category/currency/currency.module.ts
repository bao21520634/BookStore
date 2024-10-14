import { NgModule } from '@angular/core';

import { CurrencyRoutingModule } from './currency-routing.module';
import { CurrencyComponent } from './components/currency.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    declarations: [CurrencyComponent],
    imports: [SharedModule, CurrencyRoutingModule],
})
export class CurrencyModule {}
