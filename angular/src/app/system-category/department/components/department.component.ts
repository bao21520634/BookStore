import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from '@proxy/system-categories/departments';
import { DepartmentDto } from '@proxy/system-categories/departments/dtos';

import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
    selector: 'app-department',
    templateUrl: './department.component.html',
    styleUrls: ['./department.component.scss'],
    providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class DepartmentComponent implements OnInit {
    department = { items: [], totalCount: 0 } as PagedResultDto<DepartmentDto>;

    selectedDepartment = {} as DepartmentDto;

    form: FormGroup;

    isModalOpen = false;

    constructor(
        public readonly list: ListService,
        private departmentService: DepartmentService,
        private fb: FormBuilder,
        private confirmation: ConfirmationService,
    ) {}

    ngOnInit(): void {
        const departmentStreamCreator = (query: PagedAndSortedResultRequestDto) =>
            this.departmentService.getList(query);

        this.list.hookToQuery(departmentStreamCreator).subscribe((response) => {
            this.department = response;
        });
    }

    createDepartment() {
        this.selectedDepartment = {} as DepartmentDto;
        this.buildForm();
        this.isModalOpen = true;
    }

    editDepartment(id: string) {
        this.departmentService.get(id).subscribe((department) => {
            this.selectedDepartment = department;
            this.buildForm();
            this.isModalOpen = true;
        });
    }

    deleteDepartment(id: string) {
        this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
            if (status === Confirmation.Status.confirm) {
                this.departmentService.delete(id).subscribe(() => this.list.get());
            }
        });
    }

    buildForm() {
        this.form = this.fb.group({
            code: [this.selectedDepartment.code || null, Validators.required],
            deactive: [this.selectedDepartment.deactive || false],
            description: [this.selectedDepartment.description || null, Validators.required],
            note: [this.selectedDepartment.note || null],
            concurrencyStamp: [this.selectedDepartment.concurrencyStamp || null],
        });
    }

    save() {
        if (this.form.invalid) {
            return;
        }

        const request = this.selectedDepartment.id
            ? this.departmentService.update(this.selectedDepartment.id, this.form.value)
            : this.departmentService.create(this.form.value);

        request.subscribe(() => {
            this.isModalOpen = false;
            this.form.reset();
            this.list.get();
        });
    }

    toggleDeactive(department: DepartmentDto) {
        const updatedDepartment = { ...department, deactive: !department.deactive };
        this.departmentService.update(department.id, updatedDepartment).subscribe(() => {
            this.list.get();
        });
    }
}
