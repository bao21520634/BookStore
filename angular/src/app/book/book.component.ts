import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookService, bookTypeOptions } from '@proxy/books';
import { BookDto, AuthorLookupDto } from '@proxy/books/dtos';

import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { map, Observable } from 'rxjs';

@Component({
    selector: 'app-book',
    templateUrl: './book.component.html',
    styleUrls: ['./book.component.scss'],
    providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class BookComponent implements OnInit {
    book = { items: [], totalCount: 0 } as PagedResultDto<BookDto>;

    selectedBook = {} as BookDto;

    form: FormGroup;

    authors$: Observable<AuthorLookupDto[]>;

    bookTypes = bookTypeOptions;

    isModalOpen = false;

    constructor(
        public readonly list: ListService,
        private bookService: BookService,
        private fb: FormBuilder,
        private confirmation: ConfirmationService,
    ) {
        this.authors$ = bookService.getAuthorLookup().pipe(map((r) => r.items));
    }

    ngOnInit(): void {
        const bookStreamCreator = (query: PagedAndSortedResultRequestDto) => this.bookService.getList(query);

        this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
            this.book = response;
        });
    }

    createBook() {
        this.selectedBook = {} as BookDto;
        this.buildForm();
        this.isModalOpen = true;
    }

    editBook(id: string) {
        this.bookService.get(id).subscribe((book) => {
            this.selectedBook = book;
            this.buildForm();
            this.isModalOpen = true;
        });
    }

    delete(id: string) {
        this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
            if (status === Confirmation.Status.confirm) {
                this.bookService.delete(id).subscribe(() => this.list.get());
            }
        });
    }

    buildForm() {
        this.form = this.fb.group({
            authorId: [this.selectedBook.authorId || null, Validators.required],
            name: [this.selectedBook.name || null, Validators.required],
            type: [this.selectedBook.type || null, Validators.required],
            publishDate: [
                this.selectedBook.publishDate ? new Date(this.selectedBook.publishDate) : null,
                Validators.required,
            ],
            price: [this.selectedBook.price || null, Validators.required],
        });
    }

    save() {
        if (this.form.invalid) {
            return;
        }

        const request = this.selectedBook.id
            ? this.bookService.update(this.selectedBook.id, this.form.value)
            : this.bookService.create(this.form.value);

        request.subscribe(() => {
            this.isModalOpen = false;
            this.form.reset();
            this.list.get();
        });
    }
}
