import type { EntityDto } from '@abp/ng.core';
import type { BookType } from '../book-type.enum';

export interface AuthorLookupDto extends EntityDto<string> {
  name?: string;
}

export interface BookDto extends EntityDto<string> {
  name?: string;
  type: BookType;
  publishDate?: string;
  price: number;
  authorId?: string;
  authorName?: string;
}

export interface CreateUpdateBookDto {
  name: string;
  type: BookType;
  publishDate: string;
  price: number;
  authorId?: string;
}
