import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'


export const postApi = createApi({
    reducerPath: 'postApi',
    baseQuery: fetchBaseQuery({baseUrl: process.env.REACT_APP_API_BASE_URL + 'post/'}),
    endpoints: builder => ({
        getPosts: builder.query({
            query: () => 'getAll'
        }),
        getPostsByAuthorId: builder.query({
            query: (authorId) => `getAllByAuthorId/${authorId}`
        }),
        getPostById: builder.query({
            query: (id) => `getById/${id}`
        }),
        addPost: builder.mutation({
            query: (post
                    // ,userToken
            ) => ({
              url:'add',
              method:'POST',
              body:post,
              //headers:  {authorization: `Bearer ${userToken}` }
            })
        })
    })


})
export const {
    useGetPostsQuery,
    useGetPostsByAuthorIdQuery,
    useGetPostByIdQuery,
    useAddPostMutation
} = postApi;
