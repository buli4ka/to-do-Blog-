import React from "react";
import { Redirect, Route, Switch} from "react-router-dom";
import {Main} from "./Pages/Main/Main";
import {AddPost} from "./Pages/AddPost/AddPost";
import {PostDetail} from "./Pages/PostDetait/PostDetail";
import {Profile} from "./Pages/Profile/Profile";
import PostsByAuthor from "./Pages/PostsByAuthor/PostsByAuthor";
import Subs from "./Pages/Profile/Subs/Subs";


export const Router = ({user}) => {

    const PublicRoutes =
        <Switch>
            <Route path={process.env.REACT_APP_CLIENT_HOME} component={Main} exact/>
            <Route path={process.env.REACT_APP_CLIENT_DETAIL_POST} component={PostDetail} exact/>
            <Route path={process.env.REACT_APP_CLIENT_AUTHORS_POSTS} component={PostsByAuthor} exact/>

            <Redirect to={process.env.REACT_APP_CLIENT_HOME} component={Main} exact/>

        </Switch>
    const AuthorizedRoutes =
        <Switch>
            <Route path={process.env.REACT_APP_CLIENT_HOME} component={Main} exact/>
            <Route path={process.env.REACT_APP_CLIENT_USER_PROFILE_SUBS} component={Subs} exact/>
            <Route path={process.env.REACT_APP_CLIENT_AUTHORS_POSTS} component={PostsByAuthor} exact/>
            <Route path={process.env.REACT_APP_CLIENT_DETAIL_POST} component={PostDetail} exact/>
            <Route path={process.env.REACT_APP_CLIENT_ADD_POST} component={AddPost} exact/>
            <Route path={process.env.REACT_APP_CLIENT_USER_PROFILE} component={Profile} exact/>
            <Redirect to={process.env.REACT_APP_CLIENT_HOME} component={Main} exact/>

        </Switch>

    return (

        <>{user ? AuthorizedRoutes : PublicRoutes}</>
    )

}