import React from 'react';
import {useGetPostsQuery} from "../../api/postApi";
import {Preloader} from "../../UI/Preloader/Preloader";
import {PostsList} from "../../components/PostsList/PostsList";

export const Main = () => {
    const {
        data: posts,
        isLoading,
        isSuccess,
        isError,
        error
    } = useGetPostsQuery()

    let content

    if (isLoading) {
        content = <Preloader/>
    } else if (isSuccess) {
        content =  <PostsList posts={posts} title="Posts"/>
    } else if (isError) {
        content = <div>{error.toString()}</div>
    }
    return (
        <div>
            {content}
        </div>
    );
};

