import React from "react";
import {
    createBrowserRouter,
} from "react-router-dom";

import TodoScene from "../Features/Todo/Frontend/TodoScene";

const router = createBrowserRouter([
    {
        path: "/",
        element: <TodoScene />
    }
])

export default router;