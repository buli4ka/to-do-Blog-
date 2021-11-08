import {fetchBaseQuery} from "@reduxjs/toolkit/query";


export const baseQuery = fetchBaseQuery({
    baseUrl: process.env.REACT_APP_API_BASE_URL,
    prepareHeaders: (headers,{ getState }) => {
        const token = getState().user?.user
        if (token) {
            headers.set('authorization', `Bearer ${token}`)
        }
        return headers;
    },
});

