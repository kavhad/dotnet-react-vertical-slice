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
    public static getApiV1TodoListAll(): CancelablePromise<Array<TodoListDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/v1/todo-list/all',
        });
    }

    /**
     * @param id
     * @returns TodoListDto Success
     * @throws ApiError
     */
    public static getApiV1TodoList(
        id: number,
    ): CancelablePromise<TodoListDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/v1/todo-list/{id}',
            path: {
                'id': id,
            },
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

    /**
     * @param id
     * @returns any Success
     * @throws ApiError
     */
    public static deleteApiV1TodoList(
        id: number,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/v1/todo-list/{id}',
            path: {
                'id': id,
            },
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

    /**
     * @param requestBody
     * @returns TodoListDto Success
     * @throws ApiError
     */
    public static postApiV1TodoList(
        requestBody: NewTodoListDto,
    ): CancelablePromise<TodoListDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/v1/todo-list',
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

    /**
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static putApiV1TodoListChangeName(
        requestBody: ChangeTodoListNameDto,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/v1/todo-list/changeName',
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

    /**
     * @param id
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static putApiV1TodoItemChangeName(
        id: number,
        requestBody: ChangeTodoItemNameDto,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/v1/todo-item/{id}/changeName',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

    /**
     * @param id
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static putApiV1TodoItemSetTodoStatus(
        id: number,
        requestBody: ChangeTodoItemStatusDto,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/v1/todo-item/{id}/setTodoStatus',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

}
