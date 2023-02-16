/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ChangeTodoItemNameDto } from '../models/ChangeTodoItemNameDto';
import type { ChangeTodoItemStatusDto } from '../models/ChangeTodoItemStatusDto';
import type { ChangeTodoListNameDto } from '../models/ChangeTodoListNameDto';
import type { NewTodoListDto } from '../models/NewTodoListDto';
import type { TodoListDto } from '../models/TodoListDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TodosAppApiService {

    /**
     * @returns TodoListDto Success
     * @throws ApiError
     */
    public static getTodoListAll(): CancelablePromise<Array<TodoListDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/todo-list/all',
        });
    }

    /**
     * @param id
     * @returns TodoListDto Success
     * @throws ApiError
     */
    public static getTodoList(
        id: number,
    ): CancelablePromise<TodoListDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/todo-list/{id}',
            path: {
                'id': id,
            },
        });
    }

    /**
     * @param requestBody
     * @returns TodoListDto Success
     * @throws ApiError
     */
    public static postTodoList(
        requestBody: NewTodoListDto,
    ): CancelablePromise<TodoListDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/todo-list',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static putTodoListChangeName(
        requestBody: ChangeTodoListNameDto,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/todo-list/changeName',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param id
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static putTodoItemChangeName(
        id: number,
        requestBody: ChangeTodoItemNameDto,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/todo-item/{id}/changeName',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param id
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static putTodoItemSetTodoStatus(
        id: number,
        requestBody: ChangeTodoItemStatusDto,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/todo-item/{id}/setTodoStatus',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json',
        });
    }

}
