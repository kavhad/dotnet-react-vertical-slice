/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { TodoItemDto } from './TodoItemDto';

export type TodoListDto = {
    id?: number;
    name?: string | null;
    list?: Array<TodoItemDto> | null;
};

