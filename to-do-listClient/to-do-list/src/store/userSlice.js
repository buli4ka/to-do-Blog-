import {createSlice} from "@reduxjs/toolkit";
import {USER_TOKEN_STORAGE} from "../constants/storage";
import jwt from 'jsonwebtoken';

export const initialState = {
    user: localStorage.getItem(USER_TOKEN_STORAGE) ? JSON.parse(localStorage.getItem(USER_TOKEN_STORAGE)) : null,
    error: null,
};
const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        setCredentials: (state, action) => {
            const userFromJWT = jwt.decode(action.payload.data.jwtToken)
            const user = {
                id: userFromJWT.id,
                jwtToken: action.payload.data.jwtToken,
                username: userFromJWT.username,
                // subscribers:
            };
            localStorage.setItem(USER_TOKEN_STORAGE, JSON.stringify(user));
            state.user = user;

        },
        removeCredentials: (state) => {
            localStorage.removeItem(USER_TOKEN_STORAGE);
            state.user = null;
        },
        setError: (state, payload) => {
            state.error = payload;
        },
    }

})

export default userSlice.reducer;
export const userSelector = state => state.user;

export const {setCredentials, removeCredentials, setError} = userSlice.actions;

// export const login = (body) => async dispatch => {
//     try {
//         const request = await obtainTokens(payload);
//
//         dispatch(setCredentials(tokensRequest.data));
//     } catch (error) {  dispatch(setError(error ?? 'Unexpected error'));}
// }