import {createSlice} from "@reduxjs/toolkit";

export const initialState = {
    posts: [],
    error: null,

}

const postSlice = createSlice({
    name: 'posts',
    initialState,
    reducers: {
        addToPosts: (state, action) => {
            const post = {
                images: [],

            }

            state.posts = state.posts.concat(post)
        },
        setError: (state, payload) => {
            state.error = payload;
        },

    }
})

export const {addToPosts, setError} = postSlice.actions;
export default postSlice.reducer;
export const userSelector = state => state.posts;
