import {TodoItemDto, TodoListDto, TodosAppApiService} from "../../.generated";
import {useEffect, useState } from "react";

export default function TodoListView({todoLists}:{todoLists:TodoListDto[] | undefined}) {
    
    return <div>
            {todoLists?.map(tl => 
            <p key={tl.id}>
            <h3>{tl.name}</h3><ul>{
            tl.list?.map(ti => 
                <li style={{listStyleType:"none"}} key={ti.id}><TodoListItem ti={ti} /></li>)}
            </ul>
            </p>)}
    </div>
}

const TodoListItem = ({ti}:{ti:TodoItemDto}) => {
    const [isComplete, setIsComplete] = useState(ti.isComplete);
    return <label>
            <input type="checkbox" {...{checked: isComplete}} onClick={() => setIsComplete(p => !p)} /> {ti.name}
        </label>;
}