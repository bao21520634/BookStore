import { NgModule } from '@angular/core';

import { KindOfFalRoutingModule } from './kind-of-fal-routing.module';
import { KindOfFalComponent } from './components/kind-of-fal.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    declarations: [KindOfFalComponent],
    imports: [SharedModule, KindOfFalRoutingModule],
})
export class KindOfFalModule {}
