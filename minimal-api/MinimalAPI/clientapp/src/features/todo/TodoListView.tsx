import {TodoListDto, TodosAppApiService} from "../../.generated";
import {useEffect, useState } from "react";

export default function TodoListView({}) {
    
    const [todoLists, setTodolists] = useState<TodoListDto[]>()
    
    useEffect( () => {
        TodosAppApiService
            .getTodoListAll()
            .then(todoListResult => {
                setTodolists(todoListResult)
            })
            
    },[]);
    
    return <div>
            {todoLists?.map(tl => 
            <p>
            <h3>{tl.name}</h3><ul>{
            tl.list?.map(ti => 
                <li><input type="checkbox" {...{checked: ti.isComplete}} /> {ti.name}</li>)}
            </ul>
            </p>)}
    </div>
}