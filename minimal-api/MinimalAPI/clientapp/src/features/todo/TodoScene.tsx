import TodoListView from "./TodoListView";
import {useEffect, useState} from "react";
import {TodosAppApiService} from "../../.generated";
import {TodoListDto} from "../../.generated";

export default function TodoScene() {
    
    const [todoLists, setTodoLists] = useState<TodoListDto[]>();
    
    useEffect( () => {
        TodosAppApiService
            .getTodoListAll()
            .then(res => {
                if(res.length === 0)
                    TodosAppApiService.postTodoList({
                        name: "My todos",
                        list: [{
                            name: "MinimalAPI",
                            isComplete: false
                        }]
                    }).then(res => {
                        setTodoLists([res]);
                    })
                else 
                    setTodoLists(res);
            })
    }, []);
    
    return <div style={{"margin":"1em 0 0 1em"}}>
        <h2>{"Todo Lists"}</h2>
        <TodoListView todoLists={todoLists} />
    </div>
}