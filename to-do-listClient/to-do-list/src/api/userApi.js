import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'
import {useSelector} from "react-redux";
import {userSelector} from "../store/userSlice";


export const userApi = createApi({
    reducerPath: 'userApi',
    baseQuery: fetchBaseQuery({baseUrl: process.env.REACT_APP_API_BASE_URL + 'user/'}),
    endpoints: builder => ({
        authenticate: builder.mutation({
            query: initialUser => ({
                url: 'authenticate',
                method: 'POST',
                body: initialUser
            })
        }),
        register: builder.mutation({
            query: initialUser => ({
                url: 'register',
                method: 'POST',
                body: initialUser
            })
        }),
        getAuthorById: builder.query({
            query: (authorId) => ({
                url: `getAuthorById/${authorId}`,
                method: 'GET',

            })
        }),
        getById: builder.query({
            query: (user) => ({
                url:`getById/${user.id}`,
                method:'GET',
                headers:{
                    'Authorization': `Bearer ${user.jwtToken}`
                }

            })
        }),
        subscribe: builder.mutation({
            query: (initialUser) => ({
                url: 'subscribe',
                method: 'POST',
                body: initialUser.ids,
                headers:{
                    'Authorization': `Bearer ${initialUser.jwt}`
                }
            })
        }),
        unsubscribe: builder.mutation({
            query: initialUser => ({
                url: 'unsubscribe',
                method: 'POST',
                body: initialUser.ids,
                headers:{
                    'Authorization': `Bearer ${initialUser.jwt}`
                }
            })
        }),
        update: builder.mutation({
            query: (initialUser) => ({
                url: `update/${initialUser.id}`,
                method: 'PUT',
                body: initialUser
            })
        }),
    })
})
export const {
    useAuthenticateMutation,
    useGetAuthorByIdQuery,
    useGetByIdQuery,
    useSubscribeMutation,
    useUpdateMutation,
    useUnsubscribeMutation,
    useRegisterMutation
} = userApi;