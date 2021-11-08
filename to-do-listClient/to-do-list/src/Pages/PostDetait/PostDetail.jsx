import React, {useEffect, useState} from 'react';
import {useHistory, useParams} from "react-router-dom";
import {useGetPostByIdQuery} from "../../api/postApi";
import {Preloader} from "../../UI/Preloader/Preloader";
import {Gallery} from "../../UI/Gallery/Gallery";
import axios from "axios";

import styles from './PostDetail.module.css'
import {useGetAuthorByIdMutation} from "../../api/userApi";

export const PostDetail = () => {
    const history = useHistory()
    const postId = useParams().id
    const [images, setImages] = useState()
    const [author, setAuthor] = useState({})
    const [loadingImages, setLoadingImages] = useState(true)
    const {data: post, isFetching, isSuccess} = useGetPostByIdQuery(postId)
    useEffect(() => {


        const fetchImages = async () => {
            const fetchedImages = await axios(process.env.REACT_APP_API_BASE_URL + `image/getIds/${postId}`)

            setImages(fetchedImages.data)
            console.log(fetchedImages.data)
        }
        fetchImages().then(() => setLoadingImages(false))

    }, [postId])

    let content;
    if (isFetching)
        content = <Preloader/>
    if (isSuccess) {
        content = <>
            <div>
                {!loadingImages &&
                <Gallery serverDomain={process.env.REACT_APP_API_BASE_URL} serverApi={'image/getById/'}
                         images={images}/>}
            </div>
            <h1>{post?.title}
                <p className={styles.author}
                   onClick={() => history.push('/authorPosts/' + post?.authorId)}>
                    By {post?.author.username}
                </p>
            </h1>

            <div>
                <p>

                    <br/>
                    {post?.text}
                </p></div>
        </>
    }
    return (
        <div className={styles.container}>
            {content}
        </div>
    );
};

