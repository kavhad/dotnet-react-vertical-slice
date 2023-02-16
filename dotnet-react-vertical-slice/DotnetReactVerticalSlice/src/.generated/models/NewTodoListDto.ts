/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { NewTodoItem } from './NewTodoItem';

export type NewTodoListDto = {
    name?: string | null;
    list?: Array<NewTodoItem> | null;
};

