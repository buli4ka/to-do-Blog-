import {createSlice} from "@reduxjs/toolkit";
import {REACT_APP_CLIENT_THEME_LOCALSTORAGE} from "../constants/storage";

const storageTheme = () => {
    return JSON.parse(
        localStorage.getItem(REACT_APP_CLIENT_THEME_LOCALSTORAGE)
    )
}
const initialState = {
    isDark: true
}

const themeSlice = createSlice({
    name: 'theme',
    initialState: storageTheme() ? storageTheme() : initialState,
    reducers: {
        changeTheme(state, action) {
            localStorage.setItem(process.env.REACT_APP_CLIENT_THEME_LOCALSTORAGE,
                JSON.stringify({isDark: action.payload}))
            state.isDark = action.payload
        }
    }
})

export const {changeTheme} = themeSlice.actions
export default themeSlice.reducer

export const selectTheme = state => storageTheme()?.isDark ? storageTheme().isDark : state.theme.isDark