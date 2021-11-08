import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const imageApi = createApi({
   reducerPath:'imageApi',
   baseQuery:fetchBaseQuery({baseUrl:process.env.REACT_APP_API_BASE_URL+'image/'}),
   endpoints: builder=>({
      getPostImages:builder.query({
         query:(postId) =>`getIds/${postId}`
      }),
      getPostPreview:builder.query({
         query:(postId) =>`getPreview/${postId}`
      }),

   }),

});
export const {
   useGetPostImagesQuery,
   useGetPostPreviewQuery
} = imageApi;
