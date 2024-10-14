import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { KindOfFalService } from '@proxy/system-categories/kind-of-fals';
import { KindOfFalDto } from '@proxy/system-categories/kind-of-fals/dtos';

import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
    selector: 'app-kind-of-fal',
    templateUrl: './kind-of-fal.component.html',
    styleUrls: ['./kind-of-fal.component.scss'],
    providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class KindOfFalComponent implements OnInit {
    kindOfFal = { items: [], totalCount: 0 } as PagedResultDto<KindOfFalDto>;

    selectedKindOfFal = {} as KindOfFalDto;

    form: FormGroup;

    isModalOpen = false;

    constructor(
        public readonly list: ListService,
        private kindOfFalService: KindOfFalService,
        private fb: FormBuilder,
        private confirmation: ConfirmationService,
    ) {}

    ngOnInit(): void {
        const kindOfFalStreamCreator = (query: PagedAndSortedResultRequestDto) => this.kindOfFalService.getList(query);

        this.list.hookToQuery(kindOfFalStreamCreator).subscribe((response) => {
            this.kindOfFal = response;
        });
    }

    createKindOfFal() {
        this.selectedKindOfFal = {} as KindOfFalDto;
        this.buildForm();
        this.isModalOpen = true;
    }

    editKindOfFal(id: string) {
        this.kindOfFalService.get(id).subscribe((kindOfFal) => {
            this.selectedKindOfFal = kindOfFal;
            this.buildForm();
            this.isModalOpen = true;
        });
    }

    deleteKindOfFal(id: string) {
        this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
            if (status === Confirmation.Status.confirm) {
                this.kindOfFalService.delete(id).subscribe(() => this.list.get());
            }
        });
    }

    buildForm() {
        this.form = this.fb.group({
            code: [this.selectedKindOfFal.code || null, Validators.required],
            deactive: [this.selectedKindOfFal.deactive || false],
            description: [this.selectedKindOfFal.description || null, Validators.required],
            note: [this.selectedKindOfFal.note || null],
            concurrencyStamp: [this.selectedKindOfFal.concurrencyStamp || null],
        });
    }

    save() {
        if (this.form.invalid) {
            return;
        }

        const request = this.selectedKindOfFal.id
            ? this.kindOfFalService.update(this.selectedKindOfFal.id, this.form.value)
            : this.kindOfFalService.create(this.form.value);

        request.subscribe(() => {
            this.isModalOpen = false;
            this.form.reset();
            this.list.get();
        });
    }

    toggleDeactive(kindOfFal: KindOfFalDto) {
        const updatedKindOfFal = { ...kindOfFal, deactive: !kindOfFal.deactive };
        this.kindOfFalService.update(kindOfFal.id, updatedKindOfFal).subscribe(() => {
            this.list.get();
        });
    }
}
