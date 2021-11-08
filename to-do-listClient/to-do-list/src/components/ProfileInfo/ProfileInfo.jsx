import React, {useState} from 'react';
import {ImageInput} from "../../UI/ImageInput/ImageInput";
import {Button} from "../../UI/Button/Button";
import {Input} from "../../UI/Input/Input";

import styles from './ProfileInfo.module.css'
import {useSelector} from "react-redux";
import {userSelector} from "../../store/userSlice";
import {useUpdateMutation} from "../../api/userApi";
import {useHistory} from "react-router-dom";
import axios from "axios";

const ProfileInfo = ({user}) => {
    const mainUser = useSelector(userSelector).user
    const [update] = useUpdateMutation()
    const [updatedUser, setUpdatedUser] = useState({id: user.id})
    const [image, setImage] = useState()
    const [imagePreview, setImagePreview] = useState( process.env.REACT_APP_API_BASE_URL + `image/getPreview/${user.id}`)
    const history = useHistory()
    const changeHandler = event => {
        setUpdatedUser({...updatedUser, [event.target.name]: event.target.value})
    }
    const filesChangeHandler = event => {
        const reader = new FileReader();
        const file = event.target.files[0];
        reader.onloadend = () => {
            setImagePreview(reader.result);
        }

        setImage(file)
        reader.readAsDataURL(file);

    }
    const Update = async () => {
        console.log(updatedUser)
        const data = await update(updatedUser)
        let fd = new FormData()
        fd.append("File", image)
        await axios.post(
            process.env.REACT_APP_API_BASE_URL + 'Image/add/' + data.data.id
            , fd
        )

        window.location.reload();
    }
     const redirectToSubs = () => {
        history.push('/profile/subs')
    }
    return (<>{
            mainUser?.id === user.id
                ?
                <div className={styles.profileInfo}>
                    <div className={styles.avatarInfo}>
                        <ImageInput
                            previews={imagePreview}
                            name="image"
                            value={user.image}
                            accept="image/jpeg,image/png,image/jpg"
                            onChange={filesChangeHandler}
                        />
                        <div className={styles.subs}>
                            <Button onClick={redirectToSubs}>Subscribers</Button>
                            <Button onClick={redirectToSubs}>Subscribed</Button>
                        </div>
                    </div>
                    <div className={styles.userInfo}>
                           <span> FirstName
                               <Input
                                   name="firstName"
                                   value={updatedUser?.firstName ?? user.firstName}
                                   onChange={changeHandler}
                                   type="text"/>
                           </span>
                        <span> LastName
                                <Input
                                    name="lastName"
                                    value={updatedUser?.lastName ?? user.lastName}
                                    onChange={changeHandler}
                                    type="text"/>
                            </span>
                        <span> UserName
                                <Input
                                    name="username"
                                    value={updatedUser?.username ?? user.username}
                                    onChange={changeHandler}
                                    type="text"/>
                            </span>
                        <Button onClick={Update}>Update</Button>

                    </div>
                </div>
                :
                <div className={styles.profileInfo}>
                    <div className={styles.avatarInfo}>
                        <ImageInput
                            previews={imagePreview}
                            name="image"
                            value={user.image}
                            disabled
                        />
                        <div className={styles.subs}>
                            <Button onClick={redirectToSubs}>Subscribers</Button>
                            <Button onClick={redirectToSubs}>Subscribed</Button>
                        </div>
                    </div>
                    <div className={styles.userInfo}>
                           <span> FirstName
                               <Input
                                   name="firstName"
                                   value={user.firstName}
                                   disabled
                                   type="text"/>
                           </span>
                        <span> LastName
                                <Input
                                    name="lastName"
                                    value={user.lastName}
                                    disabled
                                    type="text"/>
                            </span>
                        <span> UserName
                                <Input
                                    name="username"
                                    value={user.username}
                                    disabled
                                    type="text"/>
                            </span>
                    </div>
                </div>
        }</>
    );
};

export default ProfileInfo;