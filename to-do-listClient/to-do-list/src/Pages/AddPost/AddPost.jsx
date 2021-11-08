import React, {useState} from 'react';
import {ImageInput} from "../../UI/ImageInput/ImageInput";
import {Input} from "../../UI/Input/Input";
import {Textarea} from "../../UI/Textarea/Textarea";
import styles from './AddPost.module.css'
import {Button} from "../../UI/Button/Button";
import {useDispatch, useSelector} from "react-redux";
import {userSelector} from "../../store/userSlice";
import {useAddPostMutation} from "../../api/postApi";
import axios from "axios";
import {addToPosts} from "../../store/postSlice";
import {useHistory} from "react-router-dom";

export const AddPost = () => {
    const user = useSelector(userSelector).user
    const dispatch = useDispatch()
    const [post, setPost] = useState({authorId: user.id})
    const [addPost, {isLoading}] = useAddPostMutation()
    const [images, setImages] = useState([])
    const [imagePreviews, setImagePreviews] = useState()
    const history = useHistory();
    const changeHandler = event => {
        setPost({...post, [event.target.name]: event.target.value})
    }
    const filesChangeHandler = event => {

        const reader = new FileReader();
        const file = event.target.files[0];
        reader.onloadend = () => {
            setImagePreviews(reader.result);

        }

        reader.readAsDataURL(file);


        setImages([...images, ...event.target.files])
    }
    const Add = async (event) => {
        try {
            console.log(post)
            const data = await addPost(post
                // , user.jwtToken
            )
            let fd = new FormData()
            for (let i in images) {
                fd = new FormData()
                fd.append("File", images[i])
                await axios.post(
                    process.env.REACT_APP_API_BASE_URL + 'Image/add/' + data.data.id
                    , fd
                )

            }
            dispatch(addToPosts(data.data))
            history.push('/')
        } catch (e) {
            console.log(e)
        }
    }
    return (
        <div>
            <form className={styles.form}>
                <ImageInput previews={imagePreviews} name="image" value={post.image} onChange={filesChangeHandler}
                            accept="image/jpeg,image/png,image/jpg" multiple/>
                <div className={styles.textInput}>
                    <Input name="title" value={post.title} onChange={changeHandler} type="text"
                           placeholder="Title"/>
                    <Textarea name="text" value={post.text} onChange={changeHandler} type="text"
                              placeholder="Text"/>
                </div>
                <Button disabled={isLoading} onClick={Add}>Add post</Button>
            </form>
        </div>
    );
};
