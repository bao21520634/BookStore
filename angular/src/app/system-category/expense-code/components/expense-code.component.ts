import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ExpenseCodeService } from '@proxy/system-categories/expense-codes';
import { ExpenseCodeDto } from '@proxy/system-categories/expense-codes/dtos';

import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
    selector: 'app-expense-code',
    templateUrl: './expense-code.component.html',
    styleUrls: ['./expense-code.component.scss'],
    providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class ExpenseCodeComponent implements OnInit {
    expenseCode = { items: [], totalCount: 0 } as PagedResultDto<ExpenseCodeDto>;

    selectedExpenseCode = {} as ExpenseCodeDto;

    form: FormGroup;

    isModalOpen = false;

    constructor(
        public readonly list: ListService,
        private expenseCodeService: ExpenseCodeService,
        private fb: FormBuilder,
        private confirmation: ConfirmationService,
    ) {}

    ngOnInit(): void {
        const expenseCodeStreamCreator = (query: PagedAndSortedResultRequestDto) =>
            this.expenseCodeService.getList(query);

        this.list.hookToQuery(expenseCodeStreamCreator).subscribe((response) => {
            this.expenseCode = response;
        });
    }

    createExpenseCode() {
        this.selectedExpenseCode = {} as ExpenseCodeDto;
        this.buildForm();
        this.isModalOpen = true;
    }

    editExpenseCode(id: string) {
        this.expenseCodeService.get(id).subscribe((expenseCode) => {
            this.selectedExpenseCode = expenseCode;
            this.buildForm();
            this.isModalOpen = true;
        });
    }

    deleteExpenseCode(id: string) {
        this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
            if (status === Confirmation.Status.confirm) {
                this.expenseCodeService.delete(id).subscribe(() => this.list.get());
            }
        });
    }

    buildForm() {
        this.form = this.fb.group({
            code: [this.selectedExpenseCode.code || null, Validators.required],
            deactive: [this.selectedExpenseCode.deactive || false],
            description: [this.selectedExpenseCode.description || null, Validators.required],
            note: [this.selectedExpenseCode.note || null],
            concurrencyStamp: [this.selectedExpenseCode.concurrencyStamp || null],
        });
    }

    save() {
        if (this.form.invalid) {
            return;
        }

        const request = this.selectedExpenseCode.id
            ? this.expenseCodeService.update(this.selectedExpenseCode.id, this.form.value)
            : this.expenseCodeService.create(this.form.value);

        request.subscribe(() => {
            this.isModalOpen = false;
            this.form.reset();
            this.list.get();
        });
    }

    toggleDeactive(expenseCode: ExpenseCodeDto) {
        const updatedExpenseCode = { ...expenseCode, deactive: !expenseCode.deactive };
        this.expenseCodeService.update(expenseCode.id, updatedExpenseCode).subscribe(() => {
            this.list.get();
        });
    }
}
