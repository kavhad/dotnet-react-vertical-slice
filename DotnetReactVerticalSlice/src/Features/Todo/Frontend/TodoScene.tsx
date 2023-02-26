import TodoListView from "./TodoListView";
import {useEffect, useState} from "react";
import {TodosAppApiService, TodoListDto} from "../../../Frontend/.generated";

export default function TodoScene() {
    
    const [todoLists, setTodoLists] = useState<TodoListDto[]>();
    
    useEffect( () => {
        TodosAppApiService
            .getApiV1TodoListAll()
            .then(res => {
                setTodoLists(res);
            })
    }, []);
    
    return <div style={{"margin":"1em 0 0 1em"}}>
        <h2>{"Todo Lists"}</h2>
        <TodoListView todoLists={todoLists} />
    </div>
}