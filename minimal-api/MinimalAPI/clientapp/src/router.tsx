import React from "react";
import {
    createBrowserRouter,
} from "react-router-dom";

import TodoScene from "./features/todo/TodoScene";

const router = createBrowserRouter([
    {
        path: "/",
        element: <TodoScene />
    }
])

export default router;