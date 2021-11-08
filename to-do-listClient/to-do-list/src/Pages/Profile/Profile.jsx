import React from 'react';
import {useSelector} from "react-redux";
import {userSelector} from "../../store/userSlice";
import {useGetByIdQuery} from "../../api/userApi";
import {Preloader} from "../../UI/Preloader/Preloader";
import {PostsList} from "../../components/PostsList/PostsList";
import ProfileInfo from "../../components/ProfileInfo/ProfileInfo";

export const Profile = () => {
    const user = useSelector(userSelector).user
    const {data: userData, isFetching, isSuccess} = useGetByIdQuery(user)
    // const [update, {isLoading}] = useUpdateMutation()
    // const [updatedUser, setUpdatedUser] = useState({id: user.id})
    // const [image, setImage] = useState()
    // const [imagePreview, setImagePreview] = useState()
    // const history = useHistory()
    //
    // const changeHandler = event => {
    //     setUpdatedUser({...updatedUser, [event.target.name]: event.target.value})
    // }
    // const filesChangeHandler = event => {
    //     const reader = new FileReader();
    //     const file = event.target.files[0];
    //     reader.onloadend = () => {
    //         setImagePreview(reader.result);
    //     }
    //     setImage(file)
    //     reader.readAsDataURL(file);
    //
    // }
    // const Update = async () => {
    //     console.log(updatedUser)
    //     const data = await update(updatedUser)
    //     let fd = new FormData()
    //     fd.append("File", image)
    //     await axios.post(
    //         process.env.REACT_APP_API_BASE_URL + 'Image/add/' + data.data.id
    //         , fd
    //     )
    //
    //     window.location.reload();
    // }
    //
    // const redirectToSubs = () => {
    //     history.push('/profile/subs')
    // }
    let content;
    if (isFetching)
        content = <Preloader/>
    if (isSuccess)
        content =
            <>
                <ProfileInfo user={userData}/>
                <PostsList posts={userData.posts} title="Posts"/>
            </>


    return (
        <div>
            {content}
        </div>
    );
}

