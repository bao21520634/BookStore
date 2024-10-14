import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VATService } from '@proxy/system-categories/vats';
import { VATDto } from '@proxy/system-categories/vats/dtos';

import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
    selector: 'app-vat',
    templateUrl: './vat.component.html',
    styleUrls: ['./vat.component.scss'],
    providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class VatComponent implements OnInit {
    vat = { items: [], totalCount: 0 } as PagedResultDto<VATDto>;

    selectedVat = {} as VATDto;

    form: FormGroup;

    isModalOpen = false;

    constructor(
        public readonly list: ListService,
        private vatService: VATService,
        private fb: FormBuilder,
        private confirmation: ConfirmationService,
    ) {}

    ngOnInit(): void {
        const vatStreamCreator = (query: PagedAndSortedResultRequestDto) => this.vatService.getList(query);

        this.list.hookToQuery(vatStreamCreator).subscribe((response) => {
            this.vat = response;
        });
    }

    createVat() {
        this.selectedVat = {} as VATDto;
        this.buildForm();
        this.isModalOpen = true;
    }

    editVat(id: string) {
        this.vatService.get(id).subscribe((vat) => {
            this.selectedVat = vat;
            this.buildForm();
            this.isModalOpen = true;
        });
    }

    deleteVat(id: string) {
        this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
            if (status === Confirmation.Status.confirm) {
                this.vatService.delete(id).subscribe(() => this.list.get());
            }
        });
    }

    buildForm() {
        this.form = this.fb.group({
            code: [this.selectedVat.code || null, Validators.required],
            deactive: [this.selectedVat.deactive || false],
            value: [this.selectedVat.value || null, Validators.required],
            description: [this.selectedVat.description || null, Validators.required],
            note: [this.selectedVat.note || null],
            concurrencyStamp: [this.selectedVat.concurrencyStamp || null],
        });
    }

    save() {
        if (this.form.invalid) {
            return;
        }

        const request = this.selectedVat.id
            ? this.vatService.update(this.selectedVat.id, this.form.value)
            : this.vatService.create(this.form.value);

        request.subscribe(() => {
            this.isModalOpen = false;
            this.form.reset();
            this.list.get();
        });
    }

    toggleDeactive(vat: VATDto) {
        const updatedVat = { ...vat, deactive: !vat.deactive };
        this.vatService.update(vat.id, updatedVat).subscribe(() => {
            this.list.get();
        });
    }
}
