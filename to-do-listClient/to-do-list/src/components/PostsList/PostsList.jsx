import React from 'react';
import {PostCard} from "../PostCard/PostCard";
import styles from './PostList.module.css'

export const PostsList = ({posts, title}) => {
        if (!posts.length) {
            return (
                <h1 style={{textAlign: 'center'}}>
                    Posts not found!
                </h1>)
        }


        return (
            <div>
                <h1 style={{textAlign: 'center'}}>
                    {title}
                </h1>
                <div className={styles.content}>
                    {posts.map(post => {
                        return (<PostCard key={post.id} post={post}/>)

                    })}

                </div>
            </div>


        );
    }

;