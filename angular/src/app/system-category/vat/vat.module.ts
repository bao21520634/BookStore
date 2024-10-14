import { NgModule } from '@angular/core';

import { VatRoutingModule } from './vat-routing.module';
import { VatComponent } from './components/vat.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    declarations: [VatComponent],
    imports: [SharedModule, VatRoutingModule],
})
export class VatModule {}
