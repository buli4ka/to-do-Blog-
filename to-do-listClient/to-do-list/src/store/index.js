import {configureStore} from "@reduxjs/toolkit";
import themeReducer from "./themeSlice"
import {postApi} from "../api/postApi";
import {userApi} from "../api/userApi";
import userSlice from "./userSlice";
import postSlice from "./postSlice";
import {imageApi} from "../api/imageApi";

export const store = configureStore({
    reducer: {
        theme: themeReducer,
        user: userSlice,
        post: postSlice,
        [postApi.reducerPath]: postApi.reducer,
        [imageApi.reducerPath]: imageApi.reducer,
        [userApi.reducerPath]: userApi.reducer
    },
    middleware: (getDefaultMiddleware) => [
        ...getDefaultMiddleware()
        , postApi.middleware
        , userApi.middleware
        , imageApi.middleware

    ],
})