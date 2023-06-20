import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { PostAPI } from "../services/BookService";
import { ReviewAPI } from "../services/ReviewService";
import { CommentAPI } from "../services/CommentService";
import { UserAPI } from "../services/UserService";
import { TagAPI } from "../services/TagService";

import bookReducer from './reducers/BookSlice'
const rootReducer = combineReducers({
    bookReducer,
    [PostAPI.reducerPath]: PostAPI.reducer,
    [ReviewAPI.reducerPath]: ReviewAPI.reducer,
    [CommentAPI.reducerPath]: CommentAPI.reducer,
    [UserAPI.reducerPath]: UserAPI.reducer,
    [TagAPI.reducerPath]: TagAPI.reducer,
})

export const setupStore = () =>{
    return configureStore({
        reducer : rootReducer,
        middleware: (getDefaultMiddleware) =>
            getDefaultMiddleware()
            .concat(PostAPI.middleware, ReviewAPI.middleware , CommentAPI.middleware, UserAPI.middleware, TagAPI.middleware)
        
    })
}

export type RootState = ReturnType<typeof rootReducer>
export type AppStore = ReturnType<typeof setupStore>
export type AppDispatch = AppStore['dispatch']