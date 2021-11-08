import React, {useEffect, useState} from 'react';
import {Preloader} from "../../UI/Preloader/Preloader";
import {PostsList} from "../../components/PostsList/PostsList";
import {useParams} from "react-router-dom";
import {useGetAuthorByIdQuery, useSubscribeMutation, useUnsubscribeMutation} from "../../api/userApi";
import {Button} from "../../UI/Button/Button";
import {useSelector} from "react-redux";
import {userSelector} from "../../store/userSlice";
import ProfileInfo from "../../components/ProfileInfo/ProfileInfo";

const PostsByAuthor = () => {
    const user = useSelector(userSelector).user
    const authorId = useParams().id
    const {
        data: author,
        isSuccess,
        isLoading,
        isError,
        error
    } = useGetAuthorByIdQuery(authorId)
    const [subscribe] = useSubscribeMutation()
    const [unsubscribe] = useUnsubscribeMutation()
    const [initialUser] = useState({ids:{userId: user.id, authorId}, jwt: user.jwtToken})
    console.log(author)
    const [buttonText, setButtonText] = useState()
    useEffect(() => {
        if (author && user)
            setButtonText(author?.subscribers.some(i => i.id === user.id) ? 'Unsubscribe' : 'Subscribe')
    }, [author, authorId, user])

    const Subscribe = () => {
        if (buttonText === 'Subscribe') subscribe(initialUser)
        else unsubscribe(initialUser)
        // window.location.reload();
    }

    let content
    if (isLoading) {
        content = <Preloader/>
    } else if (isSuccess) {
        content =
            <div>
                <ProfileInfo user={author}/>
                {user?.id !== authorId && user && <Button onClick={Subscribe}>{buttonText}</Button>}
                <PostsList posts={author?.posts} title={"Posts by " + author?.username}/>
            </div>
    } else if (isError) {
        content = <div>{error.toString()}</div>
    }
    return (
        <div>
            {content}
        </div>
    );
};

export default PostsByAuthor;