import {TodoItemDto, TodoListDto} from "../../../Frontend/.generated";
import {useState, Fragment } from "react";
import "./TodoListView.css";

export default function TodoListView({todoLists}:{todoLists:TodoListDto[] | undefined}) {
    
    return <div>
            {todoLists?.map(tl =>
            <Fragment key={tl.id}>
                <h3>{tl.name}</h3>
                <div className="todo-list-body">
                <ul>{
                tl.list?.map(ti => 
                    <li style={{listStyleType:"none"}} key={ti.id}><TodoListItem ti={ti} /></li>)}
                </ul>
                </div>
            </Fragment>
            )}
    </div>
}

const TodoListItem = ({ti}:{ti:TodoItemDto}) => {
    const [isComplete, setIsComplete] = useState(ti.isComplete);
    return <label>
            <input type="checkbox" {...{checked: isComplete}} onChange={() => setIsComplete(p => !p)} /> {ti.name}
        </label>;
}