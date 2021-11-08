import React from "react";
import styles from "./PostCard.module.css"
import {useHistory} from "react-router-dom";


export const PostCard = (props) => {
    const history = useHistory();

    return (
        <div className={styles.card}>
            <img className={styles.img}
                onClick={() => history.push(`/detail/${props.post.id}`)}
                src={process.env.REACT_APP_API_BASE_URL + `image/getPreview/${props.post.id}`}
                alt="Post"
                />
            <div className={styles.container}>
                <h4>
                    <b>{props.post.title}</b>
                </h4>
                <p className={styles.text}>{props.post.text}</p>
            </div>
        </div>
    )
}