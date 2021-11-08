import React, {useState} from "react";
import {NavLink, useHistory} from 'react-router-dom'
import styles from './NavBar.module.css'
import {Modal} from "../../UI/Modal/Modal";
import {AuthForm} from "./AuthForm/AuthForm";
import {useDispatch, useSelector} from "react-redux";
import {changeTheme, selectTheme} from "../../store/themeSlice";
import {useAuthenticateMutation, useRegisterMutation} from "../../api/userApi";
import {removeCredentials, setCredentials, setError} from "../../store/userSlice";


export const NavBar = ({user}) => {
    const [modal, setModal] = useState(false);
    const [isLogin, setIsLogin] = useState(true)
    const theme = useSelector(selectTheme)
    const dispatch = useDispatch()
    const [authenticate] = useAuthenticateMutation()
    const [register] = useRegisterMutation()
    const history = useHistory();

    const darkTheme = ` body{ 
        background-color:#19181f; 
        color: #F0EAD6;
    }
    .${styles.loginChoice}{color:#3C3F41;}
    .${styles.themeButton}{background-color:#e2d4c4;
    color:#19181F;}`;

    const logoutHandler = event => {
        event.preventDefault()
        dispatch(removeCredentials())
        history.push('/')
    }
    const validationHandler = async (form, isLogin) => {
        try {
            let data;
            if(isLogin)
                data = await authenticate(form)
            else data = await register(form)
            dispatch(setCredentials(data))
            setModal(false)
        } catch (error) {
            dispatch(setError(error ?? 'Unexpected error'));
        }
    }
    const AuthenticatedNavbar = <>
        <NavLink className={styles.navLink}
                 to={process.env.REACT_APP_CLIENT_HOME}
                 onClick={logoutHandler}>
            Logout
        </NavLink>
        <NavLink className={styles.navLink}
                 to={process.env.REACT_APP_CLIENT_ADD_POST}>
            AddPost
        </NavLink>
        <NavLink className={styles.navLink} to={process.env.REACT_APP_CLIENT_USER_PROFILE}>
            Profile
        </NavLink>
    </>
    const PublicNavbar = <>
        <NavLink className={styles.navLink}
                 to={process.env.REACT_APP_CLIENT_HOME}
                 onClick={() => setModal(true)}>
            Login
        </NavLink>
    </>
    return (
        <nav className={styles.nav}>
            <style>
                {theme ? darkTheme : null}
            </style>
            <NavLink className={styles.navLink} style={{float: "left"}}
                     to={process.env.REACT_APP_CLIENT_HOME}>Blog</NavLink>

            {user ? AuthenticatedNavbar : PublicNavbar}


            <Modal visible={modal} setVisible={setModal}>
                <h1 className={styles.loginChoice}
                    onClick={() => setIsLogin(!isLogin)}>{
                    isLogin
                        ?
                        "Login"
                        :
                        "Registration"
                }</h1>
                <AuthForm validationHandler={validationHandler} isLogin={isLogin}/>

            </Modal>

            <button
                className={styles.themeButton}
                onClick={() => {
                    dispatch(changeTheme(!theme))
                }

                }>{theme ? 'Light' : 'Dark'}
            </button>


        </nav>
    )


}
