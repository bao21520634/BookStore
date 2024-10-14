import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CurrencyService } from '@proxy/system-categories/currencies';
import { CurrencyDto } from '@proxy/system-categories/currencies/dtos';

import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
    selector: 'app-currency',
    templateUrl: './currency.component.html',
    styleUrls: ['./currency.component.scss'],
    providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class CurrencyComponent implements OnInit {
    currency = { items: [], totalCount: 0 } as PagedResultDto<CurrencyDto>;

    selectedCurrency = {} as CurrencyDto;

    form: FormGroup;

    isModalOpen = false;

    constructor(
        public readonly list: ListService,
        private currencyService: CurrencyService,
        private fb: FormBuilder,
        private confirmation: ConfirmationService,
    ) {}

    ngOnInit(): void {
        const currencyStreamCreator = (query: PagedAndSortedResultRequestDto) => this.currencyService.getList(query);

        this.list.hookToQuery(currencyStreamCreator).subscribe((response) => {
            this.currency = response;
        });
    }

    createCurrency() {
        this.selectedCurrency = {} as CurrencyDto;
        this.buildForm();
        this.isModalOpen = true;
    }

    editCurrency(id: string) {
        this.currencyService.get(id).subscribe((currency) => {
            this.selectedCurrency = currency;
            this.buildForm();
            this.isModalOpen = true;
        });
    }

    deleteCurrency(id: string) {
        this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
            if (status === Confirmation.Status.confirm) {
                this.currencyService.delete(id).subscribe(() => this.list.get());
            }
        });
    }

    buildForm() {
        this.form = this.fb.group({
            deactive: [this.selectedCurrency.deactive || false],
            code: [this.selectedCurrency.code || null, Validators.required],
            exchangeRate: [this.selectedCurrency.exchangeRate || null, Validators.required],
            description: [this.selectedCurrency.description || null, Validators.required],
            note: [this.selectedCurrency.note || null],
            concurrencyStamp: [this.selectedCurrency.concurrencyStamp || null],
        });
    }

    save() {
        if (this.form.invalid) {
            return;
        }

        const request = this.selectedCurrency.id
            ? this.currencyService.update(this.selectedCurrency.id, this.form.value)
            : this.currencyService.create(this.form.value);

        request.subscribe(() => {
            this.isModalOpen = false;
            this.form.reset();
            this.list.get();
        });
    }

    toggleDeactive(currency: CurrencyDto) {
        const updatedCurrency = { ...currency, deactive: !currency.deactive };
        this.currencyService.update(currency.id, updatedCurrency).subscribe(() => {
            this.list.get();
        });
    }
}
